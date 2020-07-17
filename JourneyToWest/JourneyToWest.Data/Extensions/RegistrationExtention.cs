using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Extensions
{
    public static partial class ToolExtention
    {
        private static IQueryable<Registration> Filter(this IQueryable<Registration> query, RegistrationFilter filter)
        {
            if (filter.Username != null)
            {
                query = query.Where(s => filter.Username.Contains(s.Username));
            }
            return query;
        }
        private static IQueryable<Registration> Sort(this IQueryable<Registration> query, string sort)
        {
            if (sort != null && sort.Length > 0)
            {
                var asc = sort[0] == 'a';
                var fieldName = sort.Split(" ")[1];
                switch (fieldName)
                {
                    case RegistrationFieldsSort.Name:
                        if (asc)
                        {
                            query = query.OrderBy(s => s.Username);
                        }
                        else
                        {
                            query = query.OrderByDescending(s => s.Username);
                        }
                        break;
                }
            }
            return query;
        }
        private static IQueryable<Registration> Pagination(this IQueryable<Registration> query, int page, int limit)
        {
            if (limit > -1 && page >= 0)
            {
                query = query.Skip(page * limit).Take(limit);
            }
            return query;
        }
        private static object SelectField(this IQueryable<Registration> query, string[] fields, int total)
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
                        case RegistrationFieldsDetail.INFO:
                            obj["username"] = l.Username;
                            obj["password"] = l.Password;
                            obj["Role"] = l.Role.RoleName;
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
        public static object GetData(this IQueryable<Registration> query, RegistrationFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            query = query.Pagination(page, limit);
            query = query.Sort(sort);
            var result = query.SelectField(fields, total);
            return result;
        }
    }
}
