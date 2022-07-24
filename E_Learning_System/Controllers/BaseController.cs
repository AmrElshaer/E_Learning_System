using Mediator.Net;
using System;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator Mediator => DependencyResolver.Current.GetService<IMediator>();
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, "Home", "Error");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

        }
    }
}