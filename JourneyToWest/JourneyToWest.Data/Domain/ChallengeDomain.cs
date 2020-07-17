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
    public class ChallengeDomain : BaseDomain
    {
        public ChallengeDomain(IUnitOfWork uow) : base(uow)
        {
        }

        public DbSet<ChallengeTool> GetChallengeTool()
        {
            return uow.GetService<IChallengeToolRepository>().Get();
        }

        public object GetDetailChallengeTool(ChallengeFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = GetChallengeTool();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit, totalPage);
        }


        public DbSet<Challenge> Get()
        {
            return uow.GetService<IChallengeRepository>().Get();
        }

        public object GetDetail(ChallengeFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = Get();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit, totalPage);
        }
        public Challenge Create(ChallengeCreateModel model)
        {
            return uow.GetService<IChallengeRepository>().createChallenge(model);
        }
        public ChallengeTool AddToolToChallenge(AddToolToChallengeModel model)
        {
            return uow.GetService<IChallengeToolRepository>().addToolToChallenge(model);
        }
        public Challenge Update(string id, ChallengeUpdateModel model)
        {
            var repo = uow.GetService<IChallengeRepository>();
            var challenge = repo.Get().Where(s => s.ChallengeId == id).FirstOrDefault();
            if (challenge != null)
            {
                var updatedChallenge = repo.Edit(challenge, model);
                return repo.Update(updatedChallenge).Entity;
            }
            return null;
        }
    }
}
