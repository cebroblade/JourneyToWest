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
        private static IQueryable<Tool> Filter(this IQueryable<Tool> query, ToolFilter filter)
        {
            if (filter.Ids != null)
            {
                query = query.Where(s => filter.Ids.Contains(s.ToolId));
            }
            if (filter.Name != null && filter.Name.Length > 0)
            {
                query = query.Where(s => s.Name.Contains(filter.Name));
            }

            return query;
        }
        private static IQueryable<Tool> Sort(this IQueryable<Tool> query, string sort)
        {
            if (sort != null && sort.Length > 0)
            {
                var asc = sort[0] == 'a';
                var fieldName = sort.Split(" ")[1];
                switch (fieldName)
                {
                    case ToolFieldsSort.Name:
                        if (asc)
                        {
                            query = query.OrderBy(s => s.Name);
                        }
                        else
                        {
                            query = query.OrderByDescending(s => s.Name);
                        }
                        break;
                }
            }
            return query;
        }
        private static IQueryable<Tool> Pagination(this IQueryable<Tool> query, int page, int limit)
        {
            if (limit > -1 && page >= 0)
            {
                query = query.Skip(page * limit).Take(limit);
            }
            return query;
        }
        private static object SelectField(this IQueryable<Tool> query, string[] fields, int total)
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
                            obj["id"] = l.ToolId;
                            obj["name"] = l.Name;
                            obj["description"] = l.Description;
                            obj["quantity"] = l.Quantity.ToString();
                            obj["status"] = l.Status;
                            obj["image"] = l.ImageTool;
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
        public static object GetData(this IQueryable<Tool> query, ToolFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            query = query.Pagination(page, limit);
            query = query.Sort(sort);
            var result = query.SelectField(fields, total);
            return result;
        }
    }
}
