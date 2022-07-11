using Mediator.Net;
using System.Web.Mvc;

namespace E_Learning_System.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator Mediator => DependencyResolver.Current.GetService<IMediator>();
    }
}