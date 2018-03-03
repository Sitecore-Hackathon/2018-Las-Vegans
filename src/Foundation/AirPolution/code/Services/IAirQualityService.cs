using System.Threading.Tasks;
using LV.AirPolution.Models;

namespace LV.AirPolution.Services
{
    public interface IAirQualityService
    {
        Task<AirQualityResponse> GetAirQuality(AirQualityRequest request);
    }
}
