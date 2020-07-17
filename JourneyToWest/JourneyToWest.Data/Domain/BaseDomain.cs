using JourneyToWest.JourneyToWest.Data.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Domain
{
    public abstract class BaseDomain
    {
        protected readonly IUnitOfWork uow;

        public BaseDomain(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
