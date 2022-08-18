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

namespace ELearning.Application.Department.Queries.GetDepartments
{
    public class GetDepartmentQueries : BaseRequestQuery, IRequest
    {
        public GetDepartmentQueries(DataManagerRequest dataManager = null) : base(dataManager)
        {
        }


        public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentQueries, QueryResult<DepartmentDto>>
        {
            private readonly StudentsEntities _context;
            private readonly IMapper _mapper;
            private readonly IDataProcess _dataProcess;

            public GetDepartmentsQueryHandler(StudentsEntities context, IMapper mapper, IDataProcess dataProcess)
            {
                _context = context;
                _mapper = mapper;
                _dataProcess = dataProcess;
            }


            public async Task<QueryResult<DepartmentDto>> Handle(IReceiveContext<GetDepartmentQueries> context,
                CancellationToken cancellationToken)
            {
                var students = _context.Departments.AsNoTracking().AsQueryable();
                var dm = context.Message.DM;
                var res = await _dataProcess.ApplySearchQuery(dm, students, s => s.DepartmentCode);
                return new QueryResult<DepartmentDto>()
                {
                    count = res.Count,
                    result
                        = _mapper.Map<IList<DepartmentDto>>(res.Result)
                };
            }
        }
    }
}
