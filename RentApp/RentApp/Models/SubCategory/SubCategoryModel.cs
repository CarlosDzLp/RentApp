using System;
using Newtonsoft.Json;

namespace RentApp.Models.SubCategory
{
    public class SubCategoryModel
    {
        [JsonProperty("NameSubCategory")]
        public string NameSubCategory { get; set; }

        [JsonProperty("IdCategory")]
        public Guid IdCategory { get; set; }

        [JsonProperty("IdSubCategory")]
        public Guid IdSubCategory { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("ImageByte")]
        public object ImageByte { get; set; }
    }
}
