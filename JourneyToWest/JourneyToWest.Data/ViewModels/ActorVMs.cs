using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.ViewModels
{
    public class ActorFilter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string[] Ids { get; set; }

    }
    public class ActorFieldsSort
    {
        public const string Name = "name";
    }
    public class ActorFieldsDetail
    {
        public const string INFO = "info";
        public const string DETAIL = "detail";
    }
    public class ActorCreateModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }


    }
    public class ActorUpdateModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
    public class ActorStatusUpdateModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
