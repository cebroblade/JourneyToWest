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
    [Route("api/challenge")]
    [ApiController]
    public class ChallengeController : BaseController
    {
        public ChallengeController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ChallengeFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {
            try
            {
                var domain = _uow.GetService<ChallengeDomain>();
                if (fields.Length == 0)
                {
                    fields = new string[] { ChallengeFieldsDetail.INFO };

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
        public IActionResult Create([FromBody] ChallengeCreateModel model)
        {
            try
            {
                Challenge challenge = _uow.GetService<ChallengeDomain>().Create(model);
                if (challenge != null)
                {
                    _uow.SaveChanges();
                    return Success(challenge.ChallengeId);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost("add-tool-to-challenge")]
        public IActionResult AddToolToChallenge([FromBody] AddToolToChallengeModel model)
        {
            try
            {
                ChallengeTool challengeTool = _uow.GetService<ChallengeDomain>().AddToolToChallenge(model);
                if (challengeTool != null)
                {
                    _uow.SaveChanges();
                    return Success(challengeTool.Id);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update([FromQuery]string id, [FromBody] ChallengeUpdateModel model)
        {
            try
            {
                Challenge updated = _uow.GetService<ChallengeDomain>().Update(id, model);
                if (updated != null)
                {
                    _uow.SaveChanges();
                    return Success(updated.ChallengeId);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpGet("get-challenge-tool")]
        public IActionResult GetChallengeTool([FromQuery] ChallengeFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {
            try
            {
                var domain = _uow.GetService<ChallengeDomain>();
                if (fields.Length == 0)
                {
                    fields = new string[] { ChallengeFieldsDetail.INFO };

                }
                var result = domain.GetDetailChallengeTool(filter, sort, fields, page, limit);
                return Success(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}