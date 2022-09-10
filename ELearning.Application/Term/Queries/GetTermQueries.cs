using AutoMapper;
using ELearning.Application.Common.Interfaces;
using ELearning.Application.Common.Query;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Term.Queries
{
    public class GetTermQueries : BaseRequestQuery, IRequest
    {

        public GetTermQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {

        }



        public class GetTermQueriesHandler : IRequestHandler<GetTermQueries, QueryResult<TermDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;
            private readonly IDataProcess _dataProcess;

            public GetTermQueriesHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
                _dataProcess = dataProcess;
            }


            public async Task<QueryResult<TermDto>> Handle(IReceiveContext<GetTermQueries> context, CancellationToken cancellationToken)
            {

                var terms = _context.Terms.AsNoTracking().AsQueryable();
                var dm = context.Message.DM;
                var res = await _dataProcess.ApplySearchQuery(dm, data: terms, s => s.TermId);
                return new QueryResult<TermDto>()
                {
                    count = res.Count,
                    result
                        = _mapper.Map<IList<TermDto>>(res.Result)
                };

            }
        }
    }
}
