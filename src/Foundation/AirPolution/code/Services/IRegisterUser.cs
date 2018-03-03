using System.Threading.Tasks;

namespace LV.AirPolution.Services
{
    public interface IRegisterUser
    {
        void RegisterUser(string email, double latitude, double longitude);
    }
}