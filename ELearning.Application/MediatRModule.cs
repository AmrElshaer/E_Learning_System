using Autofac;
using Mediator.Net;
using Mediator.Net.Autofac;

namespace ELearning.Application
{
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