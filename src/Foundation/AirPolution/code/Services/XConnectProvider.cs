﻿using LV.AirPolution.Facets;
using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using Sitecore.XConnect.Client.Configuration;

namespace LV.AirPolution.Services
{
    public class XConnectProvider : IRegisterUser, IManageAirQuality
    {
        private const string IdSource = "web";

        private const string RegisterGoalId = "{8FFB183B-DA1A-4C74-8F3A-9729E9FCFF6A}";

        private const string DirectChannelId = "{B418E4F2-1013-4B42-A053-B6D4DCA988BF}";

        private readonly IAirQualityService _airService;
        
        public XConnectProvider()
        {
            _airService = new AirQualityService();
        }

        public void RegisterUser(string email, double latitude, double longitude)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                {
                    try
                    {
                        var contact = new Contact(new ContactIdentifier(IdSource, email, ContactIdentifierType.Known));
                        client.AddContact(contact);
                        
                        //email
                        var emails = new EmailAddressList(new EmailAddress(email, true), "Home");
                        client.SetFacet(contact, emails);

                        //geo location
                        var homeAddress = new Address()
                        {
                            GeoCoordinate = new GeoCoordinate(latitude, longitude)
                        };
                        AddressList addresses = new AddressList(homeAddress, "Home");
                        client.SetFacet(contact, AddressList.DefaultFacetKey, addresses);

                        //register goal
                        Guid channelId = Guid.Parse(DirectChannelId);
                        string userAgent = HttpContext.Current?.Request?.UserAgent;
                        var interaction = new Interaction(contact, InteractionInitiator.Brand, channelId, userAgent);
                        var goal = new Goal(Guid.Parse(RegisterGoalId), DateTime.UtcNow);
                        interaction.Events.Add(goal);
                        client.AddInteraction(interaction);

                        client.Submit();

                        //first load of air quality data
                        UpdateAirQualityForContact(contact);
                    }
                    catch (XdbExecutionException ex)
                    {
                        Log.Error($"Error while registering a contact {email}", ex, this);
                        throw ex;
                    }
                }
            }
        }

        public int GetAirQualityForContact(Contact contact)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    Contact existingContact = client.Get(contact, new ContactExpandOptions(SmogInformationFacet.DefaultFacetKey));
                    var smogFacet = existingContact.GetFacet<SmogInformationFacet>(SmogInformationFacet.DefaultFacetKey);
                    int airQuality;
                    int.TryParse(smogFacet.SmogPercentValue, out airQuality);
                    return airQuality;
                }
                catch (XdbExecutionException ex)
                {
                    Log.Error($"Error while reading air pollution info for a contact {contact.Id}", ex, this);
                    throw ex;
                }
            }
        }

        public void UpdateAirQualityForContact(Contact contact)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var existingContact = client.Get(contact, new ContactExpandOptions(AddressList.DefaultFacetKey, SmogInformationFacet.DefaultFacetKey));
                    if (existingContact == null)
                    {
                        return;
                    }

                    var addresses = contact.GetFacet<AddressList>();
                    var smogRequest = new Models.AirQualityRequest()
                    {
                        Lat = addresses.PreferredAddress.GeoCoordinate.Latitude,
                        Lon = addresses.PreferredAddress.GeoCoordinate.Longitude
                    };

                    var smogResponse = Task.Run(async () => await _airService.GetAirQuality(smogRequest)).Result;
                    var smogFacet = existingContact.GetFacet<SmogInformationFacet>(SmogInformationFacet.DefaultFacetKey);
                    if (smogFacet == null)
                    {
                        smogFacet = new SmogInformationFacet
                        {
                            SmogPercentValue = smogResponse?.Aqi.ToString()
                        };
                    }
                    else
                    {
                        smogFacet.SmogPercentValue = smogResponse?.Aqi.ToString();
                    }
                    client.SetFacet(existingContact, SmogInformationFacet.DefaultFacetKey, smogFacet);
                    client.Submit();
                }
                catch (XdbExecutionException ex)
                {
                    Log.Error($"Error while updating air pollution info for a contact {contact.Id}", ex, this);
                }
            }
        }

        public void UpdateAirQualityForContactsBatch(int size)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var goalId = Guid.Parse(RegisterGoalId);
                    IAsyncQueryable<Contact> queryable = client.Contacts
                        .Where(c => c.Interactions.Any(f => f.Events.OfType<Goal>().Any(a => a.DefinitionId == goalId)))
                        .WithExpandOptions(new ContactExpandOptions()
                        {
                            Interactions = new RelatedInteractionsExpandOptions()
                            {
                                Limit = 10
                            }
                        });

                    var enumerable = queryable.GetBatchEnumeratorSync(size);
                    while (enumerable.MoveNext())
                    {
                        foreach (var contact in enumerable.Current)
                        {
                            UpdateAirQualityForContact(contact);
                        }
                    }
                }
                catch (XdbExecutionException ex)
                {
                    Log.Error($"Error updating air quality in batch", ex, this);
                }
            }
        }
    }
}