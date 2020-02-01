using System;
using System.Threading.Tasks;
using RentApp.Models.Tokens;

namespace RentApp.Service
{
    public interface IServiceClient
    {
        Task<T> Get<T>(string url);
        Task<T> Post<T, K>(K deserialice, string url);
        Task<T> Put<T, K>(K deserialice, string url);
        Task<T> Delete<T>(string url);
        Task Authenticate();
    }
}
