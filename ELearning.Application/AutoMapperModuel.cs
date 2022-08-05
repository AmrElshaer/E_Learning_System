using Autofac;
using AutoMapper;
using ELearning.Application.Common.Mapping;

namespace ELearning.Application
{
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
}