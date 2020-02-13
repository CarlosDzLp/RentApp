using System;
using Newtonsoft.Json;

namespace RentApp.Models.Response
{
    public class Response<T>
    {
        [JsonProperty("Result")]
        public T Result { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
