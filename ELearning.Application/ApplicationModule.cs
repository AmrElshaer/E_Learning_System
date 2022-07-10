using Autofac;
using AutoMapper;
using ELearning.Application.Common.Mapping;
using ELearning.Domain;

namespace ELearning.Application
{

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // automapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<MappingProfile>();
            }
             )).AsSelf().SingleInstance();
            builder.RegisterType<StudentsEntities>().InstancePerRequest();
        }

    }
}
