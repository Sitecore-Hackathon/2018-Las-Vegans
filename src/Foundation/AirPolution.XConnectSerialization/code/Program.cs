using LV.AirPolution.Models;
using System.IO;

namespace LV.AirPolution.xConnectSerialization
{
    /// <summary>
    /// JSON generator for custom facets
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var model = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(XConnectSmogModel.Model);
            File.WriteAllText(XConnectSmogModel.Model.FullName + ".json ", model);
        }
    }
}
