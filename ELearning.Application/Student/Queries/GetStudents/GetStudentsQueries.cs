using AutoMapper;
using ELearning.Application.Common.Query;
using ELearning.Domain;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Collections.Generic;
using System.Linq;
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
                var applyFilter = _context.Students
                    .ApplyFiliter(context.Message, a => a.FirstName.Contains(context.Message.DM.SearchValue));
                var count = applyFilter.Count();
                var res = await applyFilter.ApplySkip(context.Message)
                     .ApplyTake(context.Message)
                     .Build(i => i.StudentId);
                return new QueryResult<StudentDto>()
                {
                    count = count,
                    result
                   = _mapper.Map<IList<StudentDto>>(res)
                };
            }
        }
    }
}
