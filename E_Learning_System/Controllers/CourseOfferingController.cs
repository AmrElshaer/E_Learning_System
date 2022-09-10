using E_Learning_System.Attributes;
using ELearning.Application.Common.Commond;
using ELearning.Application.Common.Query;
using ELearning.Application.CourseOffering.Commonds.CreatEditCourseOffering;
using ELearning.Application.CourseOffering.Commonds.DeletCourseOffering;
using ELearning.Application.CourseOffering.Queries;
using ELearning.Application.CourseOffering.Queries.GetCourseOffering;
using Syncfusion.EJ2.Base;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class CourseOfferingController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UrlDatasource(DataManagerRequest dm)
        {
            var result = await Mediator.RequestAsync<GetCourseOfferingQueries, QueryResult<CourseOfferingDto>>(new GetCourseOfferingQueries(dm));
            return Json(new
            {
                result = result.result,
                count = result.count
            });

        }

        [HttpPost]
        public ActionResult CreatEditPartial(CreatEditCoursOfferingCommond value)
        {

            return PartialView("_CreatEditPartial", value);
        }
        [HttpPost]
        [ValidationActionFilter]
        public async Task<ActionResult> Save(CreatEditCoursOfferingCommond value)
        {

            value.CourseOfferingId = (await Mediator.RequestAsync<CreatEditCoursOfferingCommond, BaseEntity<int>>(value)).Id;
            return Json(value);

        }
        public async Task<ActionResult> Delete(CRUDModel<CreatEditCoursOfferingCommond> value)
        {
            await Mediator.SendAsync(new DeletCoursOfferingCommond() { CourseOfferingId = (int)value.Key });
            return Json(value);
        }
    }
}
