using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ELearning.Application.Common
{
    public static class RequestValidationMiddleware
    {
        public static void UseRequestValidation<TContext>(this IPipeConfigurator<TContext> configurator)
            where TContext : IContext<IMessage>
        {




            configurator.AddPipeSpecification(new RequestValidationMiddlewareSpecification<TContext>());
        }
    }
    public class RequestValidationMiddlewareSpecification<TContext> : IPipeSpecification<TContext> where TContext : IContext<IMessage>
    {

        public RequestValidationMiddlewareSpecification()
        {

        }

        public Task AfterExecute(TContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task BeforeExecute(TContext context, CancellationToken cancellationToken)
        {


            return Task.FromResult(0);
        }

        public Task Execute(TContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task OnException(Exception ex, TContext context)
        {
            throw ex;
        }

        public bool ShouldExecute(TContext context, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
