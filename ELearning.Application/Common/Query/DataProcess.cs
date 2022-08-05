using ELearning.Application.Common.Interfaces;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ELearning.Application.Common.Query
{
    public class DataProcess : IDataProcess
    {
        public async Task<(int Count, IList<T> Result)> ApplySearchQuery<T, TKey>(DataManagerRequest dm, IQueryable<T> data, Expression<Func<T, TKey>> keySelector)
        {
            DataOperations operation = new DataOperations();
            if (dm.Sorted == null) data = data.OrderByDescending(keySelector);

            if (dm.Sorted != null && dm.Sorted.Count > 0) // Sorting
                data = operation.PerformSorting(data, dm.Sorted);

            if (dm.Where != null && dm.Where.Count > 0) // Filtering
                data = operation.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            int count = data.Count();
            if (dm.Skip != 0)
                data = operation.PerformSkip(data, dm.Skip);
            if (dm.Take != 0)
                data = operation.PerformTake(data, dm.Take);
            var reStudents = await data.ToListAsync();
            return (count, reStudents);
        }
    }
}
