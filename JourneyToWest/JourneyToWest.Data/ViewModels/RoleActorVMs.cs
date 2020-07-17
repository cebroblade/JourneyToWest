using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.ViewModels
{
    public class RoleActorFilter
    {
        [JsonProperty("id")]
        public string[] Ids { get; set; }
    }
}
