using E_Learning_System.App_Start;
using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.Student.Commonds.CreatEditStudent;
using ELearning.Application.Student.Commonds.DeletStudent;
using ELearning.Application.Student.Queries;
using ELearning.Application.Student.Queries.GetStudents;
using Syncfusion.EJ2.Base;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{

    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UrlDatasource(DataManagerRequest dm)
        {
            var result = await Mediator.RequestAsync<GetStudentsQueries, QueryResult<StudentDto>>(new GetStudentsQueries(dm));
            return Json(new
            {
                result = result.result,
                count = result.count
            });

        }

        [HttpPost]
        public ActionResult CreatEditPartial(CreatEditStudentCommond value)
        {

            return PartialView("_CreatEditPartial", value);
        }
        [HttpPost]
        [ValidationActionFilter]
        public async Task<ActionResult> Save(CreatEditStudentCommond value)
        {

            value.StudentId = (await Mediator.RequestAsync<CreatEditStudentCommond, BaseEntity<int>>(value)).Id;
            return Json(value);

        }
        public async Task<ActionResult> Delete(CRUDModel<CreatEditStudentCommond> value)
        {
            await Mediator.SendAsync(new DeletStudentCommond() { StudentId = (int)value.Key });
            return Json(value);
        }
    }
}