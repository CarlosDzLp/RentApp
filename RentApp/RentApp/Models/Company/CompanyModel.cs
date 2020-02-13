using System;
using Newtonsoft.Json;
using SQLite;

namespace RentApp.Models.Company
{
    public class CompanyModel
    {
        [JsonProperty("IdUser")]
        public Guid? IdUser { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("NameCompany")]
        public string NameCompany { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Status")]
        public bool? Status { get; set; }

        [JsonProperty("IdCompany"),PrimaryKey]
        public Guid IdCompany { get; set; }

        [JsonProperty("ImageByte")]
        public byte[] ImageByte { get; set; }
    }
}
