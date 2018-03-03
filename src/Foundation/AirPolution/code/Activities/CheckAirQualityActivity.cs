using LV.AirPolution.Services;
using Sitecore.Xdb.MarketingAutomation.Core.Activity;
using Sitecore.Xdb.MarketingAutomation.Core.Processing.Plan;

namespace LV.AirPolution.Activities
{
    public class CheckAirQualityActivity : IActivity
    {
        IManageAirQuality _airService;

        public IActivityServices Services { get; set; }

        public CheckAirQualityActivity()
        {
            _airService = new XConnectProvider();
        }

        public ActivityResult Invoke(IContactProcessingContext context)
        {
            _airService.UpdateAirQualityForContact(context.Contact);
            return new SuccessMove();
        }
    }
}