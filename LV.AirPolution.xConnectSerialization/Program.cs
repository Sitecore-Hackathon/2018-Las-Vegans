using LV.AirPolution.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.AirPolution.xConnectSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(XConnectSmogModel.Model);
            File.WriteAllText(XConnectSmogModel.Model.FullName + ".json & ", model);
        }
    }
}
