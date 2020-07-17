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
    [Route("api/actor")]
    [ApiController]
    public class ActorController : BaseController
    {
        public ActorController(IUnitOfWork uow) : base(uow)
        {
        }
        [HttpGet("get-actor")]
        public IActionResult Get([FromQuery] ActorFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {

            try
            {
                var domain = _uow.GetService<ActorDomain>();
                if (fields.Length == 0)
                {
                    fields = new string[] { ActorFieldsDetail.INFO };

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
        public IActionResult Create([FromBody] ActorCreateModel model)
        {
            try
            {
                Actor actor = _uow.GetService<ActorDomain>().Create(model);
                if (actor != null)
                {
                    _uow.SaveChanges();
                    return Success(actor.ActorId);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPut("update-actor")]
        public IActionResult Update([FromQuery]string id, [FromBody] ActorUpdateModel model)
        {
            try
            {
                Actor updated = _uow.GetService<ActorDomain>().Update(id, model);
                if (updated != null)
                {
                    _uow.SaveChanges();
                    return Success(updated.ActorId);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPut("update-status")]
        public IActionResult UpdateStatus([FromQuery]string id, [FromBody]ActorStatusUpdateModel model)
        {
            try
            {
                Actor updated = _uow.GetService<ActorDomain>().UpdateStatus(id, model);
                if (updated != null)
                {
                    _uow.SaveChanges();
                    return Success(updated.ActorId);
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