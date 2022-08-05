using Autofac;
using FluentValidation;

namespace ELearning.Application
{
    internal class FluentValidationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AssemblyScanner findValidatorsInAssembly = AssemblyScanner.FindValidatorsInAssembly(typeof(ApplicationModule).Assembly);
            foreach (AssemblyScanner.AssemblyScanResult item in findValidatorsInAssembly)
            {
                builder
                    .RegisterType(item.ValidatorType)
                    .Keyed<IValidator>(item.InterfaceType)
                    .As<IValidator>();
            }
        }
    }
}