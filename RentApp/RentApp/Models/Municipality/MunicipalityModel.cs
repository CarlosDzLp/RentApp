using System;
using Newtonsoft.Json;

namespace RentApp.Models.Municipality
{
    public class MunicipalityModel
    {
        [JsonProperty("IdMunicipality")]
        public Guid IdMunicipality { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
