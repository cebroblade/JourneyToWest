using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Repositories
{
    public partial interface IActorRepository : IBaseRepository<Actor, string>
    {
        Actor CreateActor(ActorCreateModel team);
        Actor Edit(Actor entity, ActorUpdateModel model);
        Actor EditStatus(Actor entity, ActorStatusUpdateModel model);
    }
    public partial class ActorRepository : BaseRepository<Actor, string>, IActorRepository
    {

        public ActorRepository(DbContext context) : base(context)
        {

        }

        public Actor CreateActor(ActorCreateModel model)
        {
            Actor actor = PrepareCreate(model);
            return Create(actor).Entity;
        }
        public Actor PrepareCreate(ActorCreateModel model)
        {
            Actor actor = new Actor
            {
                ActorId = Guid.NewGuid().ToString(),
                ActorName = model.Name,
                Description = model.Description,
                ImageActor = model.Image,
                Phone = model.Phone,
                Email = model.Email,
                Username = model.Username,
                Status = "Process"
            };
            return actor;
        }
        public Actor Edit(Actor entity, ActorUpdateModel model)
        {
            entity.ActorName = model.Name;
            entity.Description = model.Description;
            entity.Phone = model.Phone;
            entity.Email = model.Email;
            entity.ImageActor = model.Image;
            return entity;
        }

        public Actor EditStatus(Actor entity, ActorStatusUpdateModel model)
        {
            entity.Status = model.Status;
            return entity;
        }
    }
}
