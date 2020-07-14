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

        private async Task Authenticate(string serializer)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
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

        public async Task<TokenRequest> GetToken ()
        {
            try
            {
                var user = DbContext.Instance.GetUser();
                var auth = new AuthenticateModel();
                auth.User = user.Users;
                auth.Password = user.Password;
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(auth);
                var db = DbContext.Instance.GetToken();
                if (db != null)
                {
                    var datenow = DateTime.Now.AddMinutes(30);
                    var date = DateTime.Compare(db.Date, datenow);
                    if (date <= 0)
                    {
                        // token valido
                        return db;
                    }
                    else
                    {
                        //obtener token
                        await Authenticate(serializer);
                        return db = DbContext.Instance.GetToken();
                    }
                }
                else
                {
                    //obtengo el token del servicio e inserto
                    await Authenticate(serializer);
                    return db = DbContext.Instance.GetToken();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
