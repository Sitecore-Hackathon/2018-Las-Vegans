using Sitecore.XConnect;

namespace LV.AirPolution.Services
{
    public interface IManageAirQuality
    {
        int GetAirQualityForContact(Contact contact);

        void UpdateAirQualityForContact(Contact contact);

        void UpdateAirQualityForContactsBatch(int size);
    }
}