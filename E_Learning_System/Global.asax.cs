using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ELearning.Application.Common.Mapping;
using ELearning.Domain;
using Mediator.Net;
using Mediator.Net.Autofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace E_Learning_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // automapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<MappingProfile>();
            }
             )).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
      .As<IMapper>()
      .InstancePerLifetimeScope();
            var mediaBuilder = new MediatorBuilder();
            mediaBuilder.RegisterHandlers(typeof(ELearning.Application.Student.Commonds.CreatEditStudent.CreatEditStudentCommond).Assembly);
            builder.RegisterMediator(mediaBuilder);
            builder.RegisterType<StudentsEntities>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
