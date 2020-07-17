using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.ViewModels
{
    public class ToolFilter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string[] Ids { get; set; }

    }
    public class ToolFieldsDetail
    {
        public const string INFO = "info";
        public const string DETAIL = "detail";
    }
    public class ToolCreateModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty ("des")]
        public string Description { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
    public class ToolUpdateModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("des")]
        public string Description { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
    public class ToolUpdateStatusModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
    }
    public class ToolFieldsSort
    {
        public const string Name = "name";
    }

}
