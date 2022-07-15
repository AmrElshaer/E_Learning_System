using AutoMapper;
using ELearning.Application.Common.Query;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Degree.Queries.GetDegrees
{

    public class GetDegreesQueries : BaseRequestQuery, IRequest
    {
        public class GetDegreePursedsQueryHandler : IRequestHandler<GetDegreesQueries, QueryResult<DegreeDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;

            public GetDegreePursedsQueryHandler(StudentsEntities context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<QueryResult<DegreeDto>> Handle(IReceiveContext<GetDegreesQueries> context, CancellationToken cancellationToken)
            {
                var applyFilter = _context.Degrees
                    .ApplyFiliter(context.Message, a => a.DegreeName.Contains(context.Message.DM.SearchValue));
                var count = applyFilter.Count();
                var res = await applyFilter.ApplySkip(context.Message).ApplyTake(context.Message).Build(i => i.DegreeId);
                return new QueryResult<DegreeDto>()
                {
                    count = count,
                    result = _mapper.Map<IList<DegreeDto>>(res)
                };
            }
        }
    }
}
