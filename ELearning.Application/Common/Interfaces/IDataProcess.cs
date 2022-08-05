using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ELearning.Application.Common.Interfaces
{
    public interface IDataProcess
    {
        Task<(int Count, IList<T> Result)> ApplySearchQuery<T, TKey>(DataManagerRequest dm, IQueryable<T> data,
            Expression<Func<T, TKey>> keySelector);
    }
}
