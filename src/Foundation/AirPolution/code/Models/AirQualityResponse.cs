using System.Runtime.Serialization;

namespace LV.AirPolution.Models
{
    /// <summary>
    /// Air quality service response model
    /// </summary>
    [DataContract]
    public class AirQualityResponse
    {
        /// <summary>
        /// Air quality percentage value, greater the better
        /// </summary>
        [DataMember(Name = "breezometer_aqi")]
        public int Aqi { get; set; }

        /// <summary>
        /// Air quality text description
        /// </summary>
        [DataMember(Name = "breezometer_description")]
        public string Description { get; set; }
    }
}
