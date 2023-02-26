using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.ModsenEvents.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : ICommandHandler<DeleteEventCommand>
    {
        public Task<Result> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
