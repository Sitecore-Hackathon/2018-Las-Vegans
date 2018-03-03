using LV.AirPolution.Services;
using Microsoft.Extensions.Logging;
using Sitecore.Marketing.Automation.Activity;
using Sitecore.Xdb.MarketingAutomation.Core.Activity;
using Sitecore.Xdb.MarketingAutomation.Core.Processing.Plan;

namespace LV.AirPolution.Activities
{
    public class CheckAirQualityActivity : BaseActivity
    {
        IManageAirQuality _airService;

        public CheckAirQualityActivity(ILogger<IActivity> logger) : base(logger)
        {
            _airService = new XConnectProvider();
        }

        public override ActivityResult Invoke(IContactProcessingContext context)
        {
            _airService.UpdateAirQualityForContact(context.Contact);
            return new SuccessMove();
        }
    }
}