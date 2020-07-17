using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Extensions
{
    public static partial class RoleActorExtension
    {
        #region Filter, sort, pagination
        private static IQueryable<RoleActor> Filter(this IQueryable<RoleActor> query, RoleActorFilter filter)
        {
            if (filter.Ids != null)
            {
                query = query.Where(s => filter.Ids.Contains(s.RoleActorId));
            }
            return query;
        }


        private static object SelectField(this IQueryable<RoleActor> query, string[] fields, int total)
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
                            obj["id"] = l.RoleActorId;
                            obj["name"] = l.RoleActorName;
                            obj["file"] = l.File;
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

        public static object GetData(this IQueryable<RoleActor> query, RoleActorFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            var result = query.SelectField(fields, total);
            return result;
        }
    }
}

