using Sitecore.XConnect;
using System;

namespace LV.AirPolution.Facets
{
    /// <summary>
    /// Custom Facet for storing air quality data
    /// </summary>
    [Serializable]
    [FacetKey(DefaultFacetKey)]
    public class SmogInformationFacet : Facet
    {
        public const string DefaultFacetKey = "SmogInformationFacet";

        public SmogInformationFacet()
        {

        }

        /// <summary>
        /// Air quality percentage value, greater the better
        /// </summary>
        public string SmogPercentValue { get; set; }
    }
}