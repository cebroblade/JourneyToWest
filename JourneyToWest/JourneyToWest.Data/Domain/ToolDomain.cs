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
    public class ToolDomain : BaseDomain
    {
        public ToolDomain(IUnitOfWork uow) : base(uow)
        {
        }

        public DbSet<Tool> Get()
        {
            return uow.GetService<IToolRepository>().Get();
        }
        public object GetDetail(ToolFilter filter, string sort, string[] fields, int page, int limit)
        {
            var query = Get();
            int totalPage = 0;
            if (limit > -1)
            {
                totalPage = query.Count() / limit;
            }
            return query.GetData(filter, sort, fields, page, limit, totalPage);
        }
        public Tool Create(ToolCreateModel model)
        {
            return uow.GetService<IToolRepository>().CreateTool(model);
        }
        public Tool Update(string id,ToolUpdateModel model)
        {
            var repo = uow.GetService<IToolRepository>();
            var tool = repo.Get().Where(s => s.ToolId == id).FirstOrDefault();
            if (tool != null)
            {
                var updatedTool = repo.Edit(tool, model);
                return repo.Update(updatedTool).Entity;
            }
            return null;
        }
        public Tool UpdateStutus(string id, ToolUpdateStatusModel model)
        {
            var repo = uow.GetService<IToolRepository>();
            var tool = repo.Get().Where(s => s.ToolId == id).FirstOrDefault();
            if (tool != null)
            {
                var updatedTool = repo.EditStatus(tool, model);
                return repo.Update(updatedTool).Entity;
            }
            return null;
        }
    }
}
