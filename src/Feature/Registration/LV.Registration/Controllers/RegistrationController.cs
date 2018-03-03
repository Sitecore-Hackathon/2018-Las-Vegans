using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LV.AirPolution.Services;

namespace LV.Localization.Controllers
{
    public class RegistrationController : Controller
    { 
        [HttpPost]
        public void Register(string email, string lat, string lon)
        {
            var xConnectProvider = new XConnectProvider();

            double latPar;
            double lonPar;
            
            if(!double.TryParse(lat, out latPar))
            {
                throw new Exception("Can't parse lat parameter");
            }

            if (!double.TryParse(lon, out lonPar))
            {
                throw new Exception("Can't parse lon parameter");
            }

            xConnectProvider.RegisterUser(email, latPar, lonPar);
        }
    }
}