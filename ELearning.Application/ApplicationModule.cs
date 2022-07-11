using Autofac;
using AutoMapper;
using ELearning.Application.Common.Mapping;
using ELearning.Domain;
using Mediator.Net;
using Mediator.Net.Autofac;

namespace ELearning.Application
{

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModuel>();
            builder.RegisterModule<MediatRModule>();
            builder.RegisterType<StudentsEntities>().InstancePerRequest();
        }

    }
    internal class AutoMapperModuel : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // automapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                // Register Mapper Profile
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
        }
    }
    internal class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mediaBuilder = new MediatorBuilder();
            mediaBuilder.RegisterHandlers(typeof(ApplicationModule).Assembly);
            builder.RegisterMediator(mediaBuilder);
        }
    }
}
