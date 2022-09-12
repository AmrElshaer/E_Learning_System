using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace ELearning.Application.CourseEnrollment.Queries.GetCoursesEnrollment
{
    public class GetCoursesEnrollQueries : BaseRequestQuery, IRequest
    {
        public GetCoursesEnrollQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {
        }


        public class GetCoursesEnrollQueriesHandler : IRequestHandler<GetCoursesEnrollQueries, QueryResult<CourseEnrollmentDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;
            private readonly IDataProcess _dataProcess;

            public GetCoursesEnrollQueriesHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
                _dataProcess = dataProcess;
            }


            public async Task<QueryResult<CourseEnrollmentDto>> Handle(IReceiveContext<GetCoursesEnrollQueries> context,
                CancellationToken cancellationToken)
            {

                var courseEnrollments = _context.CourseEnrollments.AsNoTracking().ProjectTo<CourseEnrollmentDto>(_mapper.ConfigurationProvider).AsQueryable();
                var dm = context.Message.DM;
                var res = await _dataProcess.ApplySearchQuery(dm, courseEnrollments, s => s.CourseEnrollmentId);
                return new QueryResult<CourseEnrollmentDto>()
                {
                    count = res.Count,
                    result
                        = _mapper.Map<IList<CourseEnrollmentDto>>(res.Result)
                };

            }
        }
    }
}
