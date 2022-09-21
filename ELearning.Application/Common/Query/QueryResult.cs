using Mediator.Net.Contracts;
using System.Collections.Generic;

namespace ELearning.Application.Common.Query
{
    public class QueryResult<T> : IResponse
    {
        public int count { get; set; }
        public IList<T> result { get; set; }

        public QueryResult()
        {

        }
        public QueryResult(IList<T> data)
        {
            this.result = data;
        }
    }
}
