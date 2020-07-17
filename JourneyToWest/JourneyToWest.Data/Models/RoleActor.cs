using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class RoleActor
    {
        public RoleActor()
        {
            ActorRoleActor = new HashSet<ActorRoleActor>();
            ChallengeActorIdRoleActorId = new HashSet<ChallengeActorIdRoleActorId>();
        }

        public string RoleActorId { get; set; }
        public string RoleActorName { get; set; }
        public string File { get; set; }

        public virtual ICollection<ActorRoleActor> ActorRoleActor { get; set; }
        public virtual ICollection<ChallengeActorIdRoleActorId> ChallengeActorIdRoleActorId { get; set; }
    }
}
