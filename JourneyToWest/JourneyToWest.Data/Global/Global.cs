using AutoMapper;
using JourneyToWest.JourneyToWest.Data.Domain;
using JourneyToWest.JourneyToWest.Data.Repositories;
using JourneyToWest.JourneyToWest.Data.Uow;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Global
{
    public static partial class G
    {
		public static IMapper Mapper { get; private set; }
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		public static void ConfigureIoC(IServiceCollection services)
		{
			//MapperConfigs.Add(cfg =>
			//{

			//});
			//ConfigureAutomapper();
			////IoC
			services.AddScoped<IUnitOfWork, UnitOfWork>()
				.AddScoped<DbContext, JourneyToWestContext>()
				.AddScoped<IActorRepository, ActorRepository>()
				.AddScoped<ActorDomain>()
				.AddScoped<IToolRepository, ToolRepository>()
				.AddScoped<ToolDomain>()
				.AddScoped<RegistrationDomain>()
				.AddScoped<IRegistrationRepository, RegistrationRepository>()
				.AddScoped<ChallengeDomain>()
				.AddScoped<IChallengeRepository, ChallengeRepository>()
				.AddScoped<IChallengeActorIdRoleActorIdRepository,ChallengeActorIdRoleActorIdRepository>()
				.AddScoped<ChallengeActorIdRoleActorIdDomain>()
				.AddScoped<RoleActorDomain>()
				.AddScoped<IRoleActorRepository,RoleActorRepository>()
				.AddScoped<IChallengeToolRepository,ChallengeToolRepository>();

		}

		private static void ConfigureAutomapper()
		{
			//AutoMapper
			var mapConfig = new MapperConfiguration(cfg =>
			{
				foreach (var c in MapperConfigs)
				{
					c.Invoke(cfg);
				}
			});
			G.Mapper = mapConfig.CreateMapper();

		}

	}
}

