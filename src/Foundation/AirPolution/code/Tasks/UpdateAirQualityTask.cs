using LV.AirPolution.Services;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Tasks;

namespace LV.AirPolution.Tasks
{
    /// <summary>
    /// Air quality updater task, used by Sitecore Scheduled Tasks. Update air quality information for batch of contacts
    /// </summary>
    [UsedImplicitly]
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