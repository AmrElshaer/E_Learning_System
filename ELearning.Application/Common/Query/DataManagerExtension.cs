﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ELearning.Application.Common.Query
{
    public static class DataManagerExtension
    {
        public static IQueryable<Entity> ApplyTake<Entity>(this IQueryable<Entity> dataSource, BaseRequestQuery request)
        {
            return HasTakeValue(request) ? dataSource.Take(request.DM.Take.Value) : dataSource;
        }
        private static bool HasTakeValue(BaseRequestQuery request)
        {
            return !(request.DM.Take == null || request.DM.Take == 0);
        }

        public static IQueryable<Entity> ApplySkip<Entity>(this IQueryable<Entity> dataSource, BaseRequestQuery request)
        {
            return HasSkipValue(request) ? dataSource.Skip(request.DM.Skip.Value) : dataSource;
        }

        private static bool HasSkipValue(BaseRequestQuery request)
        {
            return !(request.DM.Skip == null || request.DM.Skip == 0);
        }
        public static bool HasSearchValue(BaseRequestQuery request)
        {
            return !string.IsNullOrEmpty(request.DM.SearchValue);
        }
        public static IQueryable<T> ApplyFiliter<T>(this IQueryable<T> dataSource, BaseRequestQuery request
            , Expression<Func<T, bool>> expression)
        {
            return HasSearchValue(request) ?
                dataSource.Where(expression) : dataSource;
        }

        public static async Task<IList<T>> Build<T>(this IQueryable<T> dataSource, Expression<Func<T, long>> expression)
        {

            return await dataSource.OrderByDescending(expression).ToListAsync();

        }
    }
}
