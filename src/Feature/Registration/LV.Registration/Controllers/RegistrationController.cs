using System;
using System.Web.Mvc;
using LV.AirPolution.Services;

namespace LV.Localization.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegisterUser _userService;

        public RegistrationController()
        {
            _userService = new XConnectProvider();
        }

        [HttpPost]
        public void Register(string email, string lat, string lon)
        {
            if (!double.TryParse(lat, out double latPar))
            {
                throw new Exception("Can't parse lat parameter");
            }
            if (!double.TryParse(lon, out double lonPar))
            {
                throw new Exception("Can't parse lon parameter");
            }
            _userService.RegisterUser(email, latPar, lonPar);
        }
    }
}