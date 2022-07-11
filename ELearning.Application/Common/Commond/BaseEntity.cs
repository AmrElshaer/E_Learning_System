using Mediator.Net.Contracts;

namespace ELearning.Application.Common.Commond
{
    public class BaseEntity<T> : IResponse
    {
        public T Id { get; }
        public BaseEntity(T id)
        {
            Id = id;
        }
    }
}
