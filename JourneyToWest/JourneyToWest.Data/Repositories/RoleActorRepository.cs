using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Repositories
{
    public partial interface IRoleActorRepository: IBaseRepository<RoleActor,string>
    {
        
    }
    public partial class RoleActorRepository : BaseRepository<RoleActor, string>, IRoleActorRepository
    {
        public RoleActorRepository(DbContext context) : base(context)
        {
        }

    }
}
