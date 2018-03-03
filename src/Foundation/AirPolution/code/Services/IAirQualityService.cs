using System.Threading.Tasks;
using LV.AirPolution.Models;

namespace LV.AirPolution.Services
{
    /// <summary>
    /// Air quality service caller
    /// </summary>
    public interface IAirQualityService
    {
        /// <summary>
        /// Get air quality information from web service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AirQualityResponse> GetAirQuality(AirQualityRequest request);
    }
}
