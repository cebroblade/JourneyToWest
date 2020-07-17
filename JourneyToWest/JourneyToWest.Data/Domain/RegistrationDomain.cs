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
    public class RegistrationDomain : BaseDomain
    {
        public RegistrationDomain(IUnitOfWork uow) : base(uow)
        {
        }

        public DbSet<Registration> Get()
        {
            return uow.GetService<IRegistrationRepository>().Get();
        }
        public object GetDetail(RegistrationFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = Get();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit, totalPage);
        }
        public Registration Create (RegistrationCreateModel model)
        {
            return uow.GetService<IRegistrationRepository>().CreateRegistration(model);
        }
    }
}
