using E_Learning_System.Attributes;
using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.CourseEnrollment.Commonds.CreatEditCoursEnrollment;
using ELearning.Application.CourseEnrollment.Commonds.DeletCoursEnrollment;
using ELearning.Application.CourseEnrollment.Queries;
using ELearning.Application.CourseEnrollment.Queries.GetCoursesEnrollment;
using Syncfusion.EJ2.Base;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class CourseEnrollmentController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UrlDatasource(DataManagerRequest dm)
        {
            var result = await Mediator.RequestAsync<GetCoursesEnrollQueries, QueryResult<CourseEnrollmentDto>>(new GetCoursesEnrollQueries(dm));
            return Json(new
            {
                result = result.result,
                count = result.count
            });

        }

        [HttpPost]
        public ActionResult CreatEditPartial(CourseEnrollmentDto value)
        {

            return PartialView("_CreatEditPartial", value);
        }
        [HttpPost]
        [ValidationActionFilter]
        public async Task<ActionResult> Save(CreatEditCoursEnrollmentCommond value)
        {

            value.CourseOfferingId = (await Mediator.RequestAsync<CreatEditCoursEnrollmentCommond, BaseEntity<int>>(value)).Id;
            return Json(value);

        }
        public async Task<ActionResult> Delete(CRUDModel<CreatEditCoursEnrollmentCommond> value)
        {
            await Mediator.SendAsync(new DeletCoursEnrollCommond() { CourseEnrollId = (int)value.Key });
            return Json(value);
        }
    }
}
