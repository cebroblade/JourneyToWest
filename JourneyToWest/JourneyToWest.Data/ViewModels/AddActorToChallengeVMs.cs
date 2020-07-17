using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.ViewModels
{
    public class AddActorToChallengeModel
    {
        [JsonProperty("challenge-id")]
        public string ChallengeID { get; set; }
        [JsonProperty("actor-id")]
        public string ActorID { get; set; }
        [JsonProperty("role-actor-id")]
        public string RoleActorID { get; set; }
    }
    public class ChallengeActorIdRoleActorIdFilter
    {
        [JsonProperty("Ids")]

        public string Ids{ get; set; }
        [JsonProperty("actor-id")]
        public string actorID { get; set; }

    }
}
