using E_Learning_System.Helpers.Extensions;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace E_Learning_System.App_Start
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;
            if (filterContext.HttpContext.Request.HttpMethod == "POST" && !viewData.ModelState.IsValid)
            {
                var validation = JsonConvert.SerializeObject(new { error = viewData.ModelState.AllErrors() });
                filterContext.Result = new BadRequest(validation);
            }
        }
    }
    public class BadRequest : JsonResult
    {
        public BadRequest()
        {
        }

        public BadRequest(string message)
        {
            this.Data = message;
        }

        public BadRequest(object data)
        {
            this.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = 400;
            base.ExecuteResult(context);
        }

    }
}
