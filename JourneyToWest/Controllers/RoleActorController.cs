using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyToWest.JourneyToWest.Data.Domain;
using JourneyToWest.JourneyToWest.Data.Uow;
using JourneyToWest.JourneyToWest.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JourneyToWest.Controllers
{
    [Route("api/role-actor")]
    [ApiController]
    public class RoleActorController : BaseController
    {
        public RoleActorController(IUnitOfWork uow) : base(uow)
        {
        }
        [HttpGet("get-role-actor")]
        public IActionResult Get([FromQuery] RoleActorFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {

            try
            {
                var domain = _uow.GetService<RoleActorDomain>();
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
    }
}