using AutoMapper;
using ELearning.Application.Common.Interfaces;
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
namespace ELearning.Application.CourseOffering.Queries.GetCourseOffering
{
    public class GetCourseOfferingQueries : BaseRequestQuery, IRequest
    {

        public GetCourseOfferingQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {

        }



        public class GetCourseOfferingQueriesHandler : IRequestHandler<GetCourseOfferingQueries, QueryResult<CourseOfferingDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;
            private readonly IDataProcess _dataProcess;

            public GetCourseOfferingQueriesHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
                _dataProcess = dataProcess;
            }


            public async Task<QueryResult<CourseOfferingDto>> Handle(IReceiveContext<GetCourseOfferingQueries> context, CancellationToken cancellationToken)
            {

                var queryable = _context.CourseOfferings.Include(o => o.Cours)
                    .Include(o => o.Term).AsNoTracking().AsQueryable();
                var dm = context.Message.DM;
                var res = await _dataProcess.ApplySearchQuery(dm, data: queryable, s => s.CourseOfferingId);
                return new QueryResult<CourseOfferingDto>()
                {
                    count = res.Count,
                    result
                        = _mapper.Map<IList<CourseOfferingDto>>(res.Result)
                };

            }
        }
    }
}
