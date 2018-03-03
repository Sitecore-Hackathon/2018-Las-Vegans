using Sitecore.XConnect;

namespace LV.AirPolution.Services
{
    /// <summary>
    /// Air quality management service
    /// </summary>
    public interface IManageAirQuality
    {
        /// <summary>
        /// Get air quality for given contact from xDB
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        int GetAirQualityForContact(Contact contact);

        /// <summary>
        /// Update air quality data from web service and store it to xDB
        /// </summary>
        /// <param name="contact"></param>
        void UpdateAirQualityForContact(Contact contact);

        /// <summary>
        /// For batch of contacts update air quality data from web service and store it to xDB
        /// </summary>
        /// <param name="size"></param>
        void UpdateAirQualityForContactsBatch(int size);
    }
}