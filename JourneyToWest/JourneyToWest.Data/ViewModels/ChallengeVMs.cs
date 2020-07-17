using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.ViewModels
{
    public class ChallengeFilter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string[] Ids { get; set; }

    }
    public class ChallengeFieldsDetail
    {
        public const string INFO = "info";
        public const string DETAIL = "detail";
    }
    public class ChallengeCreateModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("des")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("start-time")]
        public string StartTime { get; set; }
        [JsonProperty("end-time")]
        public string EndTime { get; set; }
        [JsonProperty("record-count")]
        public int RecordTime { get; set; }
        [JsonProperty("quantity-tool")]
        public int QuantityTool { get; set; }

    }
    public class ChallengeUpdateModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("des")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("start-time")]
        public string StartTime { get; set; }
        [JsonProperty("end-time")]
        public string EndTime { get; set; }
        [JsonProperty("record-count")]
        public int RecordTime { get; set; }
        [JsonProperty("quantity-tool")]
        public int QuantityTool { get; set; }

    }
    public class AddToolToChallengeModel { 
        [JsonProperty("challenge-id")]
        public string ChallengeID { get; set; }
        [JsonProperty("tool-id")]
        public string ToolID { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
