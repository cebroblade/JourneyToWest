using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyToWest.JourneyToWest.Data.Domain;
using JourneyToWest.JourneyToWest.Data.Uow;
using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JourneyToWest.Controllers
{
    [Route("api/tools")]
    [ApiController]
    public class ToolController : BaseController
    {
        public ToolController(IUnitOfWork uow) : base(uow)
        {
        }
        [HttpGet]
        public IActionResult Get([FromQuery] ToolFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {
            try
            {
                var domain = _uow.GetService<ToolDomain>();
                if (fields.Length == 0)
                {
                    fields = new string[] { ToolFieldsDetail.INFO };

                }
                var result = domain.GetDetail(filter, sort, fields, page, limit);
                return Success(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] ToolCreateModel model)
        {
            try
            {
                Tool tool = _uow.GetService<ToolDomain>().Create(model);
                if (tool != null)
                {
                    _uow.SaveChanges();
                    return Success(tool.ToolId);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update([FromQuery]string id, [FromBody] ToolUpdateModel model)
        {
            try
            {
                Tool updated = _uow.GetService<ToolDomain>().Update(id, model);
                if (updated != null)
                {
                    _uow.SaveChanges();
                    return Success(updated.ToolId);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPut("update-status")]
        public IActionResult UpdateStatus([FromQuery]string id, [FromBody] ToolUpdateStatusModel model)
        {
            try
            {
                Tool updated = _uow.GetService<ToolDomain>().UpdateStutus(id, model);
                if (updated != null)
                {
                    _uow.SaveChanges();
                    return Success(updated.ToolId);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}