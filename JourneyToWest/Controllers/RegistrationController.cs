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
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : BaseController
    {
        public RegistrationController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery] RegistrationFilter filter,
            [FromQuery] string sort,
            [FromQuery] string[] fields,
            [FromQuery] int page = 0,
            [FromQuery] int limit = -1)
        {
            try
            {
                var domain = _uow.GetService<RegistrationDomain>();
                if (fields.Length == 0)
                {
                    fields = new string[] { RegistrationFieldsDetail.INFO };

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
        public IActionResult Create([FromBody] RegistrationCreateModel model)
        {
            try
            {
                Registration registration = _uow.GetService<RegistrationDomain>().Create(model);
                if (registration != null)
                {
                    _uow.SaveChanges();
                    return Success(registration.Username);
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