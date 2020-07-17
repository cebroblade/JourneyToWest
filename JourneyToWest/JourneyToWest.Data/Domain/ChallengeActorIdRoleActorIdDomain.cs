using JourneyToWest.JourneyToWest.Data.Extensions;
using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.JourneyToWest.Data.Repositories;
using JourneyToWest.JourneyToWest.Data.Uow;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Domain
{
    public class ChallengeActorIdRoleActorIdDomain : BaseDomain
    {
        public ChallengeActorIdRoleActorIdDomain(IUnitOfWork uow) : base(uow)
        {

        }
        public DbSet<ChallengeActorIdRoleActorId> Get()
        {
            return uow.GetService<IChallengeActorIdRoleActorIdRepository>().Get();
        }
        public object GetDetail(ChallengeActorIdRoleActorIdFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = Get();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit, totalPage);
        }
        public ChallengeActorIdRoleActorId Create(AddActorToChallengeModel model)
        {
            return uow.GetService<IChallengeActorIdRoleActorIdRepository>().createNew(model);
        }
    }
}
