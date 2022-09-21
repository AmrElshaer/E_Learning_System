using AutoMapper;
using AutoMapper.QueryableExtensions;
using ELearning.Application.Common.Interfaces;
using ELearning.Application.Common.Query;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Schedule.Queries
{
    public class GetScheduleQueries : IRequest
    {
        public class GetScheduleQueriesHandler : IRequestHandler<GetScheduleQueries, QueryResult<ScheduleEventDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;

            public GetScheduleQueriesHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<QueryResult<ScheduleEventDto>> Handle(IReceiveContext<GetScheduleQueries> context, CancellationToken cancellationToken)
            {

                var res = await _context.ScheduleEventDatas.AsNoTracking()
                    .ProjectTo<ScheduleEventDto>(_mapper.ConfigurationProvider).ToListAsync();
                return new QueryResult<ScheduleEventDto>(res);
            }
        }
    }
}
