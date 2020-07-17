using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Extensions
{
    public static partial class AddActorToChallengeExtention
    {
        #region Filter, sort, pagination
        private static IQueryable<ChallengeActorIdRoleActorId> Filter(this IQueryable<ChallengeActorIdRoleActorId> query, ChallengeActorIdRoleActorIdFilter filter)
        {
            if (filter.Ids != null)
            {
                query = query.Where(s => filter.Ids.Contains(s.Id));
            }
            if(filter.actorID != null)
            {
                query = query.Where(s => filter.actorID.Contains(s.ActorId));
            }
            return query;
        }



        private static object SelectField(this IQueryable<ChallengeActorIdRoleActorId> query, string[] fields, int total)
        {
            var model = query.ToList();
            var listResult = new List<Dictionary<string, string>>();
            foreach (var l in model)
            {
                var obj = new Dictionary<string, string>();
                foreach (string field in fields)
                {
                    switch (field)
                    {
                        case ActorFieldsDetail.INFO:
                            obj["id"] = l.ActorId;
                            obj["challenge-name"] = l.Challenge.ChallengeName;
                            obj["start-time"] = l.Challenge.StartTime;
                            obj["end-time"] = l.Challenge.EndTime;
                            obj["actor-name"] = l.Actor.ActorName;
                            obj["username"] = l.Actor.Username;
                            obj["role-actor-name"] = l.RoleActor.RoleActorName;
                            break;
                    }
                    listResult.Add(obj);
                }
            }

            var response = new Dictionary<string, object>();
            response["result"] = listResult;
            response["totalPage"] = total;
            return response;
        }

        #endregion

        public static object GetData(this IQueryable<ChallengeActorIdRoleActorId> query, ChallengeActorIdRoleActorIdFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            var result = query.SelectField(fields, total);
            return result;
        }
    }
}

