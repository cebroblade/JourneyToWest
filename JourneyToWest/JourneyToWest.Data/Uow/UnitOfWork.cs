using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Uow
{
    public partial interface IUnitOfWork
    {
        T GetService<T>();
        int SaveChanges();
    }
    public partial class UnitOfWork : IUnitOfWork
    {
        protected readonly IServiceProvider scope;
        protected readonly DbContext context;
        public UnitOfWork(IServiceProvider scope, DbContext context)
        {
            this.scope = scope;
            this.context = context;
        }

        public T GetService<T>()
        {
            return scope.GetService<T>();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
