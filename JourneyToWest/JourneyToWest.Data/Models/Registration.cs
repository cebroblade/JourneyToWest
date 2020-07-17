using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class Registration
    {
        public Registration()
        {
            Actor = new HashSet<Actor>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Actor> Actor { get; set; }
    }
}
