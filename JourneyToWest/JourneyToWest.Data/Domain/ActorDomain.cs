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
    public class ActorDomain : BaseDomain
    {
        public ActorDomain(IUnitOfWork uow) : base(uow)
        {
        }

        public Actor Create(ActorCreateModel model)
        {
            return uow.GetService<IActorRepository>().CreateActor(model);
        }

        public DbSet<Actor> Get()
        {
            return uow.GetService<IActorRepository>().Get();
        }
        public object GetDetail(ActorFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = Get();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit,totalPage);
        }
        public Actor Update(string id, ActorUpdateModel model)
        {
            var repo = uow.GetService<IActorRepository>();
            var actor= repo.Get().Where(s => s.ActorId == id).FirstOrDefault();
            if (actor != null)
            {
                var updatedActor = repo.Edit(actor, model);
                return repo.Update(updatedActor).Entity;
            }
            return null;
        }
        public Actor UpdateStatus(string id, ActorStatusUpdateModel model)
        {
            var repo = uow.GetService<IActorRepository>();
            var actor = repo.Get().Where(s => s.ActorId == id).FirstOrDefault();
            if (actor != null)
            {
                var updatedActor = repo.EditStatus(actor, model);
                return repo.Update(updatedActor).Entity;
            }
            return null;
        }

    }
}
