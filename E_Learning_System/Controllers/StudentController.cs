
using ELearning.Application.Student.Queries.GetStudents;
using MediatR;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
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
            var result = await this.mediator.Send(new GetStudentsQueries());
            return View(result);
        }
    }
}