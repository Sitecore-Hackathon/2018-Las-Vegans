using LV.AirPolution.Services;
using Sitecore.Framework.Rules;
using Sitecore.XConnect;
using Sitecore.XConnect.Segmentation.Predicates;

namespace LV.AirPolution.Rules.Conditions
{
    public class CheckAirQualityCondition : ICondition, IMappableRuleEntity
    {
        public int AirQuality { get; set; }

        public NumericOperationType Comparison { get; set; }

        private readonly IManageAirQuality _airService;

        public CheckAirQualityCondition()
        {
            _airService = new XConnectProvider();
        }

        public bool Evaluate(IRuleExecutionContext context)
        {
            var contact = RuleExecutionContextExtensions.Fact<Contact>(context, null);
            int airQuality = _airService.GetAirQualityForContact(contact);


            if (Comparison == NumericOperationType.IsNotEqualTo)
            {
                return airQuality != AirQuality;
            }
            return NumericOperationTypeExtensions.Evaluate(Comparison, airQuality, AirQuality);
        }
    }
}