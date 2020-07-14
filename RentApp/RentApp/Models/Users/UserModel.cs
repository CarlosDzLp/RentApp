using System;
using Newtonsoft.Json;

namespace RentApp.Models.Users
{
    public class UserModel
    {
        [JsonProperty("NameMunicipality")]
        public string NameMunicipality { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("TypeUser")]
        public int TypeUser { get; set; }

        [JsonProperty("Datebirth")]
        public DateTime? Datebirth { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("IdUser")]
        public Guid IdUser { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Users")]
        public string Users { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("IdMunicipality")]
        public Guid? IdMunicipality { get; set; }

        [JsonProperty("ImageByte")]
        public byte[] ImageByte { get; set; }
    }
}
