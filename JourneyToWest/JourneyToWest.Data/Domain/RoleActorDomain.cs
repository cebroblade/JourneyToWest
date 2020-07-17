using JourneyToWest.JourneyToWest.Data.Extensions;
using JourneyToWest.JourneyToWest.Data.Repositories;
using JourneyToWest.JourneyToWest.Data.Uow;
using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Domain
{
    public class RoleActorDomain : BaseDomain
    {
        public RoleActorDomain(IUnitOfWork uow) : base(uow)
        {
        }
        public DbSet<RoleActor> Get()
        {
            return uow.GetService<IRoleActorRepository>().Get();
        }
        public object GetDetail(RoleActorFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = Get();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit, totalPage);
        }
    }
}
