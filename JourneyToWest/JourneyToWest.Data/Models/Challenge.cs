using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class Challenge
    {
        public Challenge()
        {
            ChallengeActor = new HashSet<ChallengeActor>();
            ChallengeActorIdRoleActorId = new HashSet<ChallengeActorIdRoleActorId>();
            ChallengeTool = new HashSet<ChallengeTool>();
        }

        public string ChallengeId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int RecordTime { get; set; }
        public int QuantityTool { get; set; }
        public string ChallengeName { get; set; }

        public virtual ICollection<ChallengeActor> ChallengeActor { get; set; }
        public virtual ICollection<ChallengeActorIdRoleActorId> ChallengeActorIdRoleActorId { get; set; }
        public virtual ICollection<ChallengeTool> ChallengeTool { get; set; }
    }
}
