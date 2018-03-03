using System;
using System.Globalization;
using System.Threading.Tasks;
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
            double latPar;
            double lonPar;

            if (!double.TryParse(lat, NumberStyles.Any, CultureInfo.InvariantCulture, out latPar))
            {
                throw new Exception("Can't parse lat parameter");
            }

            if (!double.TryParse(lon, NumberStyles.Any, CultureInfo.InvariantCulture, out lonPar))
            {
                throw new Exception("Can't parse lon parameter");
            }

            _userService.RegisterUser(email, latPar, lonPar);
        }
    }
}