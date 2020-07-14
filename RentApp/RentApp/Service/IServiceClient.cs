using System;
using System.Threading.Tasks;
using RentApp.Models.Tokens;

namespace RentApp.Service
{
    public interface IServiceClient
    {
        Task<T> Get<T>(string url,string token = null);
        Task<T> Post<T>(string deserialice, string url, string token = null);
        Task<T> Put<T>(string deserialice, string url, string token = null);
        Task<T> Delete<T>(string url, string token = null);
        //Task Authenticate();
    }
}
