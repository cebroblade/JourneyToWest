using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class ChallengeActor
    {
        public string Id { get; set; }
        public string ChallengeId { get; set; }
        public string ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Challenge Challenge { get; set; }
    }
}
