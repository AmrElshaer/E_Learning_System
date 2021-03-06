using Autofac;
using Autofac.Integration.Mvc;
using ELearning.Application;
using ELearning.Application.Common.Exceptions;
using FluentValidation.Mvc;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace E_Learning_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // register syncfusion licence
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(WebConfigurationManager.AppSettings["SyncfusionLicence"]);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<ApplicationModule>();
            var container = builder.Build();
            var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(new AutofacValidatorFactory(container));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;
            ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }

}
