using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.Student.Commonds.CreatEditStudent;
using ELearning.Application.Student.Commonds.DeletStudent;
using ELearning.Application.Student.Queries;
using ELearning.Application.Student.Queries.GetStudents;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
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
            var cachedData = Session["Students"] as IEnumerable<StudentDto>;
            if (cachedData == null)
            {
                var result = await Mediator.RequestAsync<GetStudentsQueries, QueryResult<StudentDto>>(new GetStudentsQueries());
                Session["Students"] = result.result;
                cachedData = result.result;

            }

            DataOperations operation = new DataOperations();
            if (dm.Sorted != null && dm.Sorted.Count > 0)// Sorting
            {
                cachedData = operation.PerformSorting(cachedData, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)// Filtering
            {
                cachedData = operation.PerformFiltering(cachedData, dm.Where, dm.Where[0].Operator);
            }
            int count = cachedData.Count();
            if (dm.Skip != 0)
                cachedData = operation.PerformSkip(cachedData, dm.Skip);
            if (dm.Take != 0)
                cachedData = operation.PerformTake(cachedData, dm.Take);

            return Json(new
            {
                result = cachedData,
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