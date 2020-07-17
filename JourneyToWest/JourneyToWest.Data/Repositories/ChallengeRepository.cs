using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Repositories
{
    public partial interface IChallengeRepository : IBaseRepository<Challenge,string>
    {
        Challenge createChallenge(ChallengeCreateModel model);
        Challenge Edit(Challenge challenge, ChallengeUpdateModel model);
    }
    public partial class ChallengeRepository : BaseRepository<Challenge, string>, IChallengeRepository
    {
        public ChallengeRepository(DbContext context) : base(context)
        {
        }


        public Challenge createChallenge(ChallengeCreateModel model)
        {
            Challenge challenge = new Challenge
            {
                ChallengeId = Guid.NewGuid().ToString(),
                ChallengeName = model.Name,
                Description = model.Description,
                Location = model.Location,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                RecordTime = model.RecordTime,
                QuantityTool = model.QuantityTool
            };
            Create(challenge);
            return challenge;
        }

        public Challenge Edit(Challenge challenge, ChallengeUpdateModel model)
        {
            challenge.ChallengeName = model.Name;
            challenge.Description = model.Description;
            challenge.Location = model.Location;
            challenge.StartTime = model.StartTime;
            challenge.EndTime = model.EndTime;
            challenge.RecordTime = model.RecordTime;
            challenge.QuantityTool = model.QuantityTool;
            return challenge;
        }
    }
    public partial interface IChallengeToolRepository : IBaseRepository<ChallengeTool, string>
    {
        ChallengeTool addToolToChallenge(AddToolToChallengeModel model);
    }
    public partial class ChallengeToolRepository : BaseRepository<ChallengeTool, string>, IChallengeToolRepository
    {
        public ChallengeToolRepository(DbContext context) : base(context)
        {
        }

        public ChallengeTool addToolToChallenge(AddToolToChallengeModel model)
        {
            ChallengeTool challengeTool = new ChallengeTool
            {
                Id = Guid.NewGuid().ToString(),
                ChallengeId = model.ChallengeID,
                ToolId = model.ToolID,
                Quantity = model.Quantity
            };
            Create(challengeTool);
            return challengeTool;
        }
    }
        
}
