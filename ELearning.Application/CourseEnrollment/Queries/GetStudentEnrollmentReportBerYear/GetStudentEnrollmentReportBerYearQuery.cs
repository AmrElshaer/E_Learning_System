using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ELearning.Application.Common.Query;
using ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollMentReport;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;

namespace ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollmentReportBerYear
{
    public class GetStudentEnrollmentReportBerYearQuery:IRequest
    {
        public int Year { get; set; }
        public class GetStudentEnrollmentReportBerYearQueryHandler : IRequestHandler<GetStudentEnrollmentReportBerYearQuery, QueryResult<CountCourseStudentsEnrollModel>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;

            public GetStudentEnrollmentReportBerYearQueryHandler(StudentsEntities context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<QueryResult<CountCourseStudentsEnrollModel>> Handle(IReceiveContext<GetStudentEnrollmentReportBerYearQuery> context, CancellationToken cancellationToken)
            {

                var coursesResults =
                    _context.CountCourse_StudentsEnroll(context.Message.Year).ToList();
                return new QueryResult<CountCourseStudentsEnrollModel>()
                {
                    count = coursesResults.Count,
                    result
                        = _mapper.Map<IList<CountCourseStudentsEnrollModel>>(coursesResults)
                };

            }
        }
    }
}
