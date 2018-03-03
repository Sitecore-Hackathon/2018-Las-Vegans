using LV.AirPolution.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Schema;

namespace LV.AirPolution.Models
{
    /// <summary>
    /// xConnect model for air quality facet
    /// </summary>
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