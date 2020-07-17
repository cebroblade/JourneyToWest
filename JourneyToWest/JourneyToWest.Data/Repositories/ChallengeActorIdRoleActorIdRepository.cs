using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Repositories
{
    public partial interface IChallengeActorIdRoleActorIdRepository : IBaseRepository<ChallengeActorIdRoleActorId,string>
    {
        ChallengeActorIdRoleActorId createNew(AddActorToChallengeModel model);
    }
    public partial class ChallengeActorIdRoleActorIdRepository : BaseRepository<ChallengeActorIdRoleActorId, string>, IChallengeActorIdRoleActorIdRepository
    {
        public ChallengeActorIdRoleActorIdRepository(DbContext context) : base(context)
        {
        }

        public ChallengeActorIdRoleActorId createNew(AddActorToChallengeModel model)
        {
            ChallengeActorIdRoleActorId challengeActorIdRoleActorId = new ChallengeActorIdRoleActorId
            {
                Id = Guid.NewGuid().ToString(),
                ChallengeId = model.ChallengeID,
                ActorId = model.ActorID,
                RoleActorId = model.RoleActorID
            };
            Create(challengeActorIdRoleActorId);
            return challengeActorIdRoleActorId;
        }
    }
}
