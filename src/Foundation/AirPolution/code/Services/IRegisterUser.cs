namespace LV.AirPolution.Services
{
    public interface IRegisterUser
    {
        /// <summary>
        /// Register contact in xDB with basic geolocation data
        /// </summary>
        /// <param name="email"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        void RegisterUser(string email, double latitude, double longitude);
    }
}