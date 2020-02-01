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
        public async Task<T> Delete<T>(string url)
        {
            try
            {
                var token = await DbContext.Instance.GettToken();
                if(token==null)
                    await Authenticate();
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                var urltype = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.DeleteAsync(urltype);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Authenticate();
                    await Delete<T>(url);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Get<T>(string url)
        {
            try
            {
                var token = await DbContext.Instance.GettToken();
                if (token == null)
                {
                    await Authenticate();
                    token = await DbContext.Instance.GettToken();
                }                   
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                var urlType = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.GetAsync(urlType);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Authenticate();
                    await Get<T>(url);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Post<T, K>(K deserialice, string url)
        {
            try
            {
                var token = await DbContext.Instance.GettToken();
                if (token == null)
                {
                    await Authenticate();
                    token = await DbContext.Instance.GettToken();
                }
                T deserializer = default(T);
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(deserialice);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.PostAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Authenticate();
                    await Post<T,K>(deserialice,url);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Put<T, K>(K deserialice, string url)
        {
            try
            {
                var token = await DbContext.Instance.GettToken();
                if (token == null)
                {
                    await Authenticate();
                    token = await DbContext.Instance.GettToken();
                }
                T deserializer = default(T);
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(deserialice);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.PutAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Authenticate();
                    await Put<T, K>(deserialice, url);
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
                    Email = "ryankar90@hotmail.com",
                    Password = "carlosdiaz90#"
                };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(tokenModel);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("authenticate/aouth", content);
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
