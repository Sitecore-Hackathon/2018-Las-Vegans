using LV.AirPolution.Facets;
using Sitecore.Framework.Rules;
using Sitecore.XConnect;
using Sitecore.XConnect.Segmentation.Predicates;
using System.Diagnostics.CodeAnalysis;

namespace LV.AirPolution.Rules.Conditions
{
    public class CheckAirQualityCondition : ICondition, IMappableRuleEntity
    {
        public int AirQuality { get; set; }

        public NumericOperationType Comparison { get; set; }

        public bool Evaluate(IRuleExecutionContext context)
        {
            var contact = RuleExecutionContextExtensions.Fact<Contact>(context, null);
            var smogFacet = contact.GetFacet<SmogInformationFacet>(SmogInformationFacet.DefaultFacetKey);

            //todo: if smogFacet not exists use this:
            //XConnectClient client = XConnectClientReference.GetClient();
            //Contact existingContact = client.Get<Contact>(contact, new ContactExpandOptions(SmogInformationFacet.DefaultFacetKey));
            //var smogFacet = existingContact.GetFacet<SmogInformationFacet>(SmogInformationFacet.DefaultFacetKey);

            int airQuality;
            if (Comparison == NumericOperationType.IsNotEqualTo)
            {
                if (int.TryParse(smogFacet.SmogPercentValue, out airQuality))
                {
                    return airQuality != AirQuality;
                }
                return true;
            }

            if (int.TryParse(smogFacet.SmogPercentValue, out airQuality))
            {
                return NumericOperationTypeExtensions.Evaluate(Comparison, airQuality, AirQuality);
            }
            return false;
        }
    }
}