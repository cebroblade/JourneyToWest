using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class ActorRoleActor
    {
        public string Id { get; set; }
        public string RoleActorId { get; set; }
        public string ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual RoleActor RoleActor { get; set; }
    }
}
