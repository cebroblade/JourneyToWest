using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Extensions
{
    public static partial class ActorExtensions
    {
        #region Filter, sort, pagination
        private static IQueryable<Actor> Filter(this IQueryable<Actor> query, ActorFilter filter)
        {
            if (filter.Ids != null)
            {
                query = query.Where(s => filter.Ids.Contains(s.ActorId));
            }
            if (filter.Name != null && filter.Name.Length > 0)
            {
                query = query.Where(s => s.ActorName.Contains(filter.Name));
            }
            if(filter.username != null)
            {
                query = query.Where(s => s.Username.Equals(filter.username));
            }

            return query;
        }

        private static IQueryable<Actor> Sort(this IQueryable<Actor> query, string sort)
        {
            if (sort != null && sort.Length > 0)
            {
                var asc = sort[0] == 'a';
                var fieldName = sort.Split(" ")[1];
                switch (fieldName)
                {
                    case ActorFieldsSort.Name:
                        if (asc)
                        {
                            query = query.OrderBy(s => s.ActorName);
                        }
                        else
                        {
                            query = query.OrderByDescending(s => s.ActorName);
                        }
                        break;
                }
            }
            return query;
        }

        private static IQueryable<Actor> Pagination(this IQueryable<Actor> query, int page, int limit)
        {
            if (limit > -1 && page >= 0)
            {
                query = query.Skip(page * limit).Take(limit);
            }
            return query;
        }

        private static object SelectField(this IQueryable<Actor> query, string[] fields,int total)
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
                            obj["name"] = l.ActorName;
                            obj["description"] = l.Description;
                            obj["phone"] = l.Phone;
                            obj["email"] = l.Email;
                            obj["image"] = l.ImageActor;
                            obj["status"] = l.Status;
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

        public static object GetData(this IQueryable<Actor> query, ActorFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            query = query.Pagination(page, limit);
            query = query.Sort(sort);
            var result = query.SelectField(fields,total);
            return result;
        }
    }
}
