using Autofac;
using ELearning.Application.Common.Interfaces;
using ELearning.Application.Common.Query;
using ELearning.Domain;

namespace ELearning.Application
{

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterModule<AutoMapperModuel>();
            builder.RegisterModule<MediatRModule>();
            builder.RegisterModule<FluentValidationModule>();
            builder.RegisterType<DataProcess>().As<IDataProcess>();
            builder.RegisterType<StudentsEntities>().InstancePerRequest();
        }

    }
}
