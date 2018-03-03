using Sitecore.XConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LV.AirPolution.Facets
{
    [Serializable]
    [FacetKey(DefaultFacetKey)]
    public class SmogInformationFacet : Facet
    {
        public const string DefaultFacetKey = "SmogInformationFacet";

        public SmogInformationFacet()
        {

        }

        public string SmogPercentValue { get; set; }
    }
}