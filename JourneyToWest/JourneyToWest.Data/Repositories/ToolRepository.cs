using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Repositories
{
    public partial interface IToolRepository : IBaseRepository<Tool,string>
    {
        Tool CreateTool(ToolCreateModel model);
        Tool Edit(Tool tool, ToolUpdateModel model);
        Tool EditStatus(Tool tool, ToolUpdateStatusModel model);
    }
    public partial class ToolRepository : BaseRepository<Tool, string>, IToolRepository
    {
        public ToolRepository(DbContext context) : base(context)
        {
        }

        public Tool CreateTool(ToolCreateModel model)
        {
            Tool newTool = new Tool()
            {
                ToolId = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
                Quantity = model.Quantity,
                ImageTool = model.Image,
                Status = "Process"
            };
            Create(newTool);
            return newTool;
        }
        public Tool Edit(Tool tool, ToolUpdateModel model)
        {
            tool.Name = model.Name;
            tool.Description = model.Description;
            tool.Quantity = model.Quantity;
            tool.ImageTool = model.Image;
            return tool;
        }
        public Tool EditStatus(Tool tool, ToolUpdateStatusModel model)
        {
            tool.Status = model.Status;
            return tool;
        }
    }
}
