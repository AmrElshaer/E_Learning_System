using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ELearning.Application.Common.Interfaces;
using ELearning.Application.Common.Query;
using ELearning.Application.CourseOffering.Queries;
using ELearning.Application.CourseOffering.Queries.GetCourseOffering;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Syncfusion.EJ2.Base;

namespace ELearning.Application.CourseEnrollment.Queries.GetStudentEnrollMentReport
{
    public class GetStudentEnrollmentReportQuery :  IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class GetStudentEnrollmentReportQueryHandler : IRequestHandler<GetStudentEnrollmentReportQuery, QueryResult<StudentEnrollmentReportModel>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;

            public GetStudentEnrollmentReportQueryHandler(StudentsEntities context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<QueryResult<StudentEnrollmentReportModel>> Handle(IReceiveContext<GetStudentEnrollmentReportQuery> context, CancellationToken cancellationToken)
            {

                var coursesResults =
                    _context.GetEnrollMentStudentReport(context.Message.FirstName, context.Message.LastName).ToList();
                return new QueryResult<StudentEnrollmentReportModel>()
                {
                    count =coursesResults.Count,
                    result
                        = _mapper.Map<IList<StudentEnrollmentReportModel>>(coursesResults)
                };

            }
        }
    }
}
