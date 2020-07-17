using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class ChallengeActorIdRoleActorId
    {
        public string Id { get; set; }
        public string ChallengeId { get; set; }
        public string ActorId { get; set; }
        public string RoleActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Challenge Challenge { get; set; }
        public virtual RoleActor RoleActor { get; set; }
    }
}
