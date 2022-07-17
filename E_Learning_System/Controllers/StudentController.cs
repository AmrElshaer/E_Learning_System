using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.Student.Commonds.CreatEditStudent;
using ELearning.Application.Student.Commonds.DeletStudent;
using ELearning.Application.Student.Queries;
using ELearning.Application.Student.Queries.GetStudents;
using Syncfusion.EJ2.Base;
using System.Linq;
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
            var result = await Mediator.RequestAsync<GetStudentsQueries, QueryResult<StudentDto>>(new GetStudentsQueries());
            var data = result.result.AsEnumerable();
            DataOperations operation = new DataOperations();
            if (dm.Sorted != null && dm.Sorted.Count > 0)// Sorting
            {
                data = operation.PerformSorting(data, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)// Filtering
            {
                data = operation.PerformFiltering(data, dm.Where, dm.Where[0].Operator);
            }
            int count = data.Count();
            if (dm.Skip != 0)
                data = operation.PerformSkip(data, dm.Skip);
            if (dm.Take != 0)
                data = operation.PerformTake(data, dm.Take);

            return Json(new
            {
                result = data,
                count = count
            });

        }

        [HttpPost]
        public ActionResult CreatEditPartial(CreatEditStudentCommond value)
        {

            return PartialView("_CreatEditPartial", value);
        }

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