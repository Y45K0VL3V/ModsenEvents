using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Messaging
{
    public interface ICommandHandler<T> : IRequestHandler<T, Result> where T : ICommand
    {
    }
}
