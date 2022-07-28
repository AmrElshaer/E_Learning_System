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

            public GetStudentsQueryHandler(StudentsEntities context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<QueryResult<StudentDto>> Handle(IReceiveContext<GetStudentsQueries> context, CancellationToken cancellationToken)
            {

                var students = _context.Students.AsNoTracking().AsQueryable();
                var dm = context.Message.DM;
                DataOperations operation = new DataOperations();
                if (dm.Sorted == null)
                {
                    students = students.OrderByDescending(s => s.StudentId);
                }
                if (dm.Sorted != null && dm.Sorted.Count > 0)// Sorting
                {
                    students = operation.PerformSorting(students, dm.Sorted);
                }
                if (dm.Where != null && dm.Where.Count > 0)// Filtering
                {
                    students = operation.PerformFiltering(students, dm.Where, dm.Where[0].Operator);
                }
                int count = students.Count();
                if (dm.Skip != 0)
                    students = operation.PerformSkip(students, dm.Skip);
                if (dm.Take != 0)
                    students = operation.PerformTake(students, dm.Take);
                var stdDtos = await students.ToListAsync();
                return new QueryResult<StudentDto>()
                {
                    count = count,
                    result
                   = _mapper.Map<IList<StudentDto>>(stdDtos)
                };

            }
        }
    }
}
