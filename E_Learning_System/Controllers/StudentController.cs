using ELearning.Application.Common.Query;
using ELearning.Application.Student.Queries;
using ELearning.Application.Student.Queries.GetStudents;
using Mediator.Net;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class Test : IRequest
    {

    }
    public class TestHandler : IRequestHandler<Test, TestResult>
    {
        public Task<TestResult> Handle(IReceiveContext<Test> context, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TestResult());
        }
    }
    public class TestResult : IResponse
    {

    }
    public class StudentController : Controller
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: Student
        public async Task<ActionResult> Index()
        {

            var result = await this.mediator
                .RequestAsync<GetStudentsQueries, QueryResult<StudentDto>>(new GetStudentsQueries()
                {
                    DM = new DataManager(take: 100)
                });
            return View(result.result);
        }
    }
}