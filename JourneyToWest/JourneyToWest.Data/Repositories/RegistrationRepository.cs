using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Repositories
{
    public partial interface IRegistrationRepository : IBaseRepository<Registration, string>
    {
        Registration CreateRegistration(RegistrationCreateModel model);
    }
    public partial class RegistrationRepository : BaseRepository<Registration, string>, IRegistrationRepository
    {
        public RegistrationRepository(DbContext context) : base(context)
        {

        }

        public Registration CreateRegistration(RegistrationCreateModel model)
        {
            Registration registration = new Registration
            {
                Username = model.Username,
                Password = model.Password,
                RoleId = "2"
            };
            Create(registration);
            return registration;
        }
    }
}
