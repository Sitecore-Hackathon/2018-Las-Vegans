using LV.AirPolution.Services;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Tasks;

namespace LV.AirPolution.Tasks
{
    public class UpdateAirQualityTask
    {
        private readonly IManageAirQuality _airService;

        public UpdateAirQualityTask()
        {
            _airService = new XConnectProvider();
        }

        public void Execute(Item[] items, CommandItem command, ScheduleItem schedule)
        {
            _airService.UpdateAirQualityForContactsBatch(10);
            Log.Info($"Update air quality task done", this);
        }
    }

}