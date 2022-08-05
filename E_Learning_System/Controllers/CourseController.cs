using E_Learning_System.Attributes;
using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.Course.Commonds.CreatEditCourse;
using ELearning.Application.Course.Commonds.DeleteCourse;
using ELearning.Application.Course.Queries.GetCourses;
using ELearning.Application.Student.Queries;
using Syncfusion.EJ2.Base;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UrlDatasource(DataManagerRequest dm)
        {
            var result = await Mediator.RequestAsync<GetCouresesQueries, QueryResult<StudentDto>>(new GetCouresesQueries(dm));
            return Json(new
            {
                result = result.result,
                count = result.count
            });

        }

        [HttpPost]
        public ActionResult CreatEditPartial(CreatEditCourseCommond value)
        {

            return PartialView("_CreatEditPartial", value);
        }
        [HttpPost]
        [ValidationActionFilter]
        public async Task<ActionResult> Save(CreatEditCourseCommond value)
        {

            value.CourseNumber = (await Mediator.RequestAsync<CreatEditCourseCommond, BaseEntity<int>>(value)).Id;
            return Json(value);

        }
        public async Task<ActionResult> Delete(CRUDModel<CreatEditCourseCommond> value)
        {
            await Mediator.SendAsync(new DeleteCourseCommond() { CourseNumber = (int)value.Key });
            return Json(value);
        }
    }


}
