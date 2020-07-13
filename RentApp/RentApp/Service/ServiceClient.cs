using System;
using System.Threading.Tasks;
using RentApp.Models.Tokens;
using System.Net.Http;
using RentApp.Helpers;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using RentApp.DataBase;

namespace RentApp.Service
{
    public class ServiceClient : IServiceClient
    {
        public async Task<T> Delete<T>(string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                var urltype = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.DeleteAsync(urltype);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Get<T>(string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                var urlType = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(urlType);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Post<T>(string deserialice, string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(deserialice, Encoding.UTF8, "application/json");
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PostAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Put<T>(string deserialice, string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(deserialice, Encoding.UTF8, "application/json");
                if(!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PutAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task Authenticate()
        {
            try
            {
                var tokenModel = new AuthenticateModel
                {
                    User = "ryankar90@hotmail.com",
                    Password = "carlosdiaz90#"
                };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(tokenModel);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("authenticate/auth", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenRequest>(responseString);
                    DbContext.Instance.InsertToken(deserializer);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
