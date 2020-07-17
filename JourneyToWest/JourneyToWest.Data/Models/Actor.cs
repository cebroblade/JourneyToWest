using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class Actor
    {
        public Actor()
        {
            ActorRoleActor = new HashSet<ActorRoleActor>();
            ChallengeActor = new HashSet<ChallengeActor>();
            ChallengeActorIdRoleActorId = new HashSet<ChallengeActorIdRoleActorId>();
        }

        public string ActorId { get; set; }
        public string ActorName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ImageActor { get; set; }
        public string Status { get; set; }

        public virtual Registration UsernameNavigation { get; set; }
        public virtual ICollection<ActorRoleActor> ActorRoleActor { get; set; }
        public virtual ICollection<ChallengeActor> ChallengeActor { get; set; }
        public virtual ICollection<ChallengeActorIdRoleActorId> ChallengeActorIdRoleActorId { get; set; }
    }
}
