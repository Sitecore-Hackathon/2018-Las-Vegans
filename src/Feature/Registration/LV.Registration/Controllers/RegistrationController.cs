using LV.AirPolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LV.Registration.Controllers
{
    public class RegistrationController : Controller
    { 
        [HttpPost]
        public ActionResult Register(string email, string lat, string lon)
        {
            return Json("");
        }

        [HttpGet]
        public ActionResult XConnectTest()
        {
            XConnectProvider xConnectProvider = new XConnectProvider();
            xConnectProvider.TestXConntect();

            return Json("");
        }
    }
}