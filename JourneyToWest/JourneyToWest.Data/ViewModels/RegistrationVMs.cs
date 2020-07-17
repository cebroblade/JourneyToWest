using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.ViewModels
{
    public class RegistrationFilter
    {
        [JsonProperty("username")]
        public string[] Username { get; set; }
        
    }
    public class RegistrationFieldsSort
    {
        public const string Name = "name";
    }
    public class RegistrationFieldsDetail
    {
        public const string INFO = "info";
        public const string DETAIL = "detail";
    }
    public class RegistrationCreateModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
