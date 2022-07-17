using AutoMapper;
using ELearning.Application.Common.Query;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Student.Queries.GetStudents
{
    public class GetStudentsQueries : BaseRequestQuery, IRequest
    {
        public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQueries, QueryResult<StudentDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;

            public GetStudentsQueryHandler(StudentsEntities context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<QueryResult<StudentDto>> Handle(IReceiveContext<GetStudentsQueries> context, CancellationToken cancellationToken)
            {
                var students = await _context.Students.AsNoTracking().ToListAsync().ConfigureAwait(false);
                return new QueryResult<StudentDto>()
                {
                    count = students.Count,
                    result
                   = _mapper.Map<IList<StudentDto>>(students)
                };
            }
        }
    }
}
