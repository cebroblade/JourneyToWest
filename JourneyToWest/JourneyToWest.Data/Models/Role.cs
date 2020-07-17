using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class Role
    {
        public Role()
        {
            Registration = new HashSet<Registration>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
