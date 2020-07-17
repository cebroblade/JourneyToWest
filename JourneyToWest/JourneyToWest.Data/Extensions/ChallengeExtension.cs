using JourneyToWest.JourneyToWest.Data.ViewModels;
using JourneyToWest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToWest.JourneyToWest.Data.Extensions
{
    public static partial class ChallengeExtention
    {
        private static IQueryable<Challenge> Filter(this IQueryable<Challenge> query, ChallengeFilter filter)
        {
            if (filter.Ids != null)
            {
                query = query.Where(s => filter.Ids.Contains(s.ChallengeId));
            }
            if (filter.Name != null && filter.Name.Length > 0)
            {
                query = query.Where(s => s.ChallengeName.Contains(filter.Name));
            }

            return query;
        }
        private static IQueryable<Challenge> Sort(this IQueryable<Challenge> query, string sort)
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
                            query = query.OrderBy(s => s.ChallengeName);
                        }
                        else
                        {
                            query = query.OrderByDescending(s => s.ChallengeName);
                        }
                        break;
                }
            }
            return query;
        }
        private static IQueryable<Challenge> Pagination(this IQueryable<Challenge> query, int page, int limit)
        {
            if (limit > -1 && page >= 0)
            {
                query = query.Skip(page * limit).Take(limit);
            }
            return query;
        }
        private static object SelectField(this IQueryable<Challenge> query, string[] fields, int total)
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
                            obj["id"] = l.ChallengeId;
                            obj["name"] = l.ChallengeName;
                            obj["des"] = l.Description;
                            obj["location"] = l.Location;
                            obj["start-time"] = l.StartTime;
                            obj["end-time"] = l.EndTime;
                            obj["record-count"] = l.RecordTime.ToString();
                            obj["quantity-tool"] = l.QuantityTool.ToString();
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
        public static object GetData(this IQueryable<Challenge> query, ChallengeFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            query = query.Pagination(page, limit);
            query = query.Sort(sort);
            var result = query.SelectField(fields, total);
            return result;
        }
    }
    public static partial class ChallengeToolExtention
    {
        private static IQueryable<ChallengeTool> Filter(this IQueryable<ChallengeTool> query, ChallengeFilter filter)
        {
            if (filter.Ids != null)
            {
                query = query.Where(s => filter.Ids.Contains(s.ChallengeId));
            }

            return query;
        }
        private static IQueryable<ChallengeTool> Pagination(this IQueryable<ChallengeTool> query, int page, int limit)
        {
            if (limit > -1 && page >= 0)
            {
                query = query.Skip(page * limit).Take(limit);
            }
            return query;
        }
        private static object SelectField(this IQueryable<ChallengeTool> query, string[] fields, int total)
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
                            obj["id"] = l.Id;
                            obj["challenge-name"] = l.Challenge.ChallengeName;
                            obj["tool-name"] = l.Tool.Name;
                            obj["quantity"] = l.Quantity.ToString();
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
        public static object GetData(this IQueryable<ChallengeTool> query, ChallengeFilter filter, string sort, string[] fields, int page, int limit, int total)
        {
            query = query.Filter(filter);
            query = query.Pagination(page, limit);
            var result = query.SelectField(fields, total);
            return result;
        }
    }
}

