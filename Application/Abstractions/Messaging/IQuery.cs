using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Messaging
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
    }
}
