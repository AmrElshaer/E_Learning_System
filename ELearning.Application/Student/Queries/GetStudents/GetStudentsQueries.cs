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

namespace ELearning.Application.Student.Queries.GetStudents
{
    public class GetStudentsQueries : BaseRequestQuery, IRequest
    {

        public GetStudentsQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {

        }



        public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQueries, QueryResult<StudentDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;
            private readonly IDataProcess _dataProcess;

            public GetStudentsQueryHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
                _dataProcess = dataProcess;
            }


            public async Task<QueryResult<StudentDto>> Handle(IReceiveContext<GetStudentsQueries> context, CancellationToken cancellationToken)
            {

                var students = _context.Students.AsNoTracking().AsQueryable();
                var dm = context.Message.DM;
                var res = await _dataProcess.ApplySearchQuery(dm, data: students, s => s.StudentId);
                return new QueryResult<StudentDto>()
                {
                    count = res.Count,
                    result
                   = _mapper.Map<IList<StudentDto>>(res.Result)
                };

            }
        }
    }
}
