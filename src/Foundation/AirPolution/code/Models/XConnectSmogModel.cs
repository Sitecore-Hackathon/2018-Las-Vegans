using LV.AirPolution.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LV.AirPolution.Models
{
    public class XConnectSmogModel
    {
        public static XdbModel Model { get; } = BuildModel();

        private static XdbModel BuildModel()
        {
            XdbModelBuilder modelBuilder = new XdbModelBuilder("XConnectSmogModel", new XdbModelVersion(0, 1));

            modelBuilder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            modelBuilder.DefineFacet<Contact, SmogInformationFacet>(SmogInformationFacet.DefaultFacetKey);

            return modelBuilder.BuildModel();
        }
    }
}