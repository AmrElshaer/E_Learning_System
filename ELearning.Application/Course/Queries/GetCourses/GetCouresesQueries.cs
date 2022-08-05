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

namespace ELearning.Application.Course.Queries.GetCourses
{
    public class GetCouresesQueries : BaseRequestQuery, IRequest
    {
        public GetCouresesQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {
        }


        public class GetCoursesQueryHandler : IRequestHandler<GetCouresesQueries, QueryResult<CourseDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;
            private readonly IDataProcess _dataProcess;

            public GetCoursesQueryHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
                _dataProcess = dataProcess;
            }


            public async Task<QueryResult<CourseDto>> Handle(IReceiveContext<GetCouresesQueries> context,
                CancellationToken cancellationToken)
            {
                var students = _context.Courses.AsNoTracking().AsQueryable();
                var dm = context.Message.DM;
                var res = await _dataProcess.ApplySearchQuery(dm, students, s => s.CourseNumber);
                return new QueryResult<CourseDto>()
                {
                    count = res.Count,
                    result
                        = _mapper.Map<IList<CourseDto>>(res.Result)
                };
            }
        }
    }
}