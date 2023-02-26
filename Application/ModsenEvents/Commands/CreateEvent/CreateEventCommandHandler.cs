using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.ModsenEvents.Commands.CreateEvent
{
    public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand>
    {
        public Task<Result> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
