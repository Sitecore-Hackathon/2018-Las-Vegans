using System.Runtime.Serialization;

namespace LV.AirPolution.Models
{
    [DataContract]
    public class AirQualityResponse
    {
        [DataMember(Name = "breezometer_aqi")]
        public int Aqi { get; set; }

        [DataMember(Name = "breezometer_description")]
        public string Description { get; set; }
    }
}
