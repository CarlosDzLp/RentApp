using System;
namespace RentAppViewModels.ViewModels
{
    public class Response<T>
    {
        public T Result { get; set; }
        public int Count { get; set; }
        public string Message { get; set; }
    }
}
