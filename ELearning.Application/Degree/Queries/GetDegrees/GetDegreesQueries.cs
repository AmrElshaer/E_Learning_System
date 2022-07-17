using AutoMapper;
using ELearning.Application.Common.Query;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Degree.Queries.GetDegrees
{

    public class GetDegreesQueries : BaseRequestQuery, IRequest
    {
        public GetDegreesQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {

        }
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
                var degrees = _context.Degrees.AsNoTracking().AsQueryable();

                var dm = context.Message.DM;
                DataOperations operation = new DataOperations();
                if (dm.Sorted == null)
                {
                    degrees = degrees.OrderByDescending(s => s.DegreeId);
                }
                if (dm.Sorted != null && dm.Sorted.Count > 0)// Sorting
                {
                    degrees = operation.PerformSorting(degrees, dm.Sorted);
                }
                if (dm.Where != null && dm.Where.Count > 0)// Filtering
                {
                    degrees = operation.PerformFiltering(degrees, dm.Where, dm.Where[0].Operator);
                }
                int count = degrees.Count();
                if (dm.Skip != 0)
                    degrees = operation.PerformSkip(degrees, dm.Skip);
                if (dm.Take != 0)
                    degrees = operation.PerformTake(degrees, dm.Take);
                var degDtos = await degrees.ToListAsync();
                return new QueryResult<DegreeDto>()
                {
                    count = count,
                    result = _mapper.Map<IList<DegreeDto>>(degDtos)
                };
            }
        }
    }
}
