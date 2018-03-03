using LV.AirPolution.Services;
using Sitecore;
using Sitecore.Xdb.MarketingAutomation.Core.Activity;
using Sitecore.Xdb.MarketingAutomation.Core.Processing.Plan;

namespace LV.AirPolution.Activities
{
    /// <summary>
    /// Marketing Automation Activity for updating contacts air quality and storing data in xDB
    /// </summary>
    [UsedImplicitly]
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