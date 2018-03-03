using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LV.AirPolution.Models;

namespace LV.AirPolution.Services
{
    public class AirQualityService : IAirQualityService
    {
        public async Task<AirQualityResponse> GetAirQuality(AirQualityRequest request)
        {
            var url = GetUrl("baqi");
            url = AddParameter(url, "lat", request.Lat.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture));
            url = AddParameter(url, "lon", request.Lon.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture));

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(responseString));
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AirQualityResponse));
                var result = serializer.ReadObject(ms) as AirQualityResponse;

                return result;
            }

            throw new Exception($"Response with code: {response.StatusCode}, message: {response.ReasonPhrase}");
        }

        private string GetUrl(string methodName)
        {
            var apiUrl = Sitecore.Configuration.Settings.GetSetting("BreezoMetterApiUrl");
            var apiKey = Sitecore.Configuration.Settings.GetSetting("BreezoMetterApiKey");

            var url = $"{apiUrl}/{methodName}";
            url = AddParameter(url, "key", apiKey);

            return url;
        }

        private string AddParameter(string url, string name, string value)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[name] = value;
            uriBuilder.Query = query.ToString();
            url = uriBuilder.ToString();

            return url;
        }
    }
}
