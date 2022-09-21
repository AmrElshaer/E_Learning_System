using ELearning.Application.Common.Query;
using ELearning.Application.Schedule.Commonds;
using ELearning.Application.Schedule.Queries;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> LoadData()  // Here we get the Start and End Date and based on that can filter the data and return to Scheduler
        {
            var data = await Mediator.RequestAsync<GetScheduleQueries, QueryResult<ScheduleEventDto>>(new GetScheduleQueries()); ;
            return Json(data.result);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> UpdateData([FromBody] UpdatScheduleCommond param)
        {
            var data = await Mediator.RequestAsync<UpdatScheduleCommond, UpdateScheduleRespone>(param); ;
            return Json(data.Schedules);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}