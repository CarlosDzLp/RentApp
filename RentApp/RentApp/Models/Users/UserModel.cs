using System;
using Newtonsoft.Json;
using SQLite;

namespace RentApp.Models.Users
{
    public class UserModel
    {
        [JsonProperty("IdUser"),PrimaryKey]
        public Guid IdUser { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("TypeLogin")]
        public int TypeLogin { get; set; }

        [JsonProperty("Type")]
        public int Type { get; set; }

        [JsonProperty("Status")]
        public bool? Status { get; set; }

        [JsonProperty("ImageByte"),Ignore]
        public byte[] ImageByte { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }
    }
}
