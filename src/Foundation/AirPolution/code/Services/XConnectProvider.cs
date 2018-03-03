using LV.AirPolution.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LV.AirPolution.Services
{
    public class XConnectProvider
    {
        public async void TestXConntect()
        {
            using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                {
                    try
                    {
                        Contact contact = new Contact(new ContactIdentifier("twitter", "myrtlesitecore", ContactIdentifierType.Known));
                        client.AddContact(contact);

                        // Facet with a reference object, key is specified
                        SmogInformationFacet personalInfoFacet = new SmogInformationFacet()
                        {
                            SmogPercentValue = "100"
                        };

                        FacetReference reference = new FacetReference(contact, SmogInformationFacet.DefaultFacetKey);
                        client.SetFacet(reference, personalInfoFacet);

                        // Facet without a reference, using default key
                        EmailAddressList emails = new EmailAddressList(new EmailAddress("myrtle@test.test", true), "Home");
                        client.SetFacet(contact, emails);

                        // Facet without a reference, key is specified
                        AddressList addresses = new AddressList(new Address() { AddressLine1 = "Cool Street 12", City = "Sitecore City", PostalCode = "ABC 123" }, "Home");
                        client.SetFacet(contact, AddressList.DefaultFacetKey, addresses);

                        // Submit operations as batch
                        await client.SubmitAsync();
                    }
                    catch (XdbExecutionException ex)
                    {

                    }
                }
            }
        }
    }
}