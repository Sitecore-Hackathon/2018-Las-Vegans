using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LV.Localization.Controllers
{
    public class RegistrationController : Controller
    { 
        [HttpPost]
        public ActionResult Register(string email, string lat, string lon)
        {
            return Json("ok");
        }
    }
}