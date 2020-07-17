using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyToWest.JourneyToWest.Data.Domain;
using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.JourneyToWest.Data.Uow;
using JourneyToWest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JourneyToWest.Controllers
{
    [Route("api/add-actor-to-challenge")]
    [ApiController]
    public class AddActorToChallengeController : BaseController
    {
        public AddActorToChallengeController(IUnitOfWork uow) : base(uow)
        {
        }
        [HttpGet("get-list-actor-in-challenge")]
        public IActionResult Get([FromQuery] ChallengeActorIdRoleActorIdFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {

            try
            {
                var domain = _uow.GetService<ChallengeActorIdRoleActorIdDomain>();
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
        public IActionResult Create([FromBody] AddActorToChallengeModel model)
        {
            try
            {
                ChallengeActorIdRoleActorId challengeActorIdRoleActorId = _uow.GetService<ChallengeActorIdRoleActorIdDomain>().Create(model);
                if (challengeActorIdRoleActorId != null)
                {
                    _uow.SaveChanges();
                    return Success(challengeActorIdRoleActorId.Id);
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