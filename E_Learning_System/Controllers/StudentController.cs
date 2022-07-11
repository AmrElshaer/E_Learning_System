using ELearning.Application.Common.Query;
using ELearning.Application.Student.Queries;
using ELearning.Application.Student.Queries.GetStudents;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{

    public class StudentController : BaseController
    {

        // GET: Student
        public async Task<ActionResult> Index()
        {

            var result = await Mediator
                .RequestAsync<GetStudentsQueries, QueryResult<StudentDto>>(new GetStudentsQueries()
                {
                    DM = new DataManager(take: 100)
                });
            return View(result.result);
        }
    }
}