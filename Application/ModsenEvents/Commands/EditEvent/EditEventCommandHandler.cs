using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.ModsenEvents.Commands.EditEvent
{
    public class EditEventCommandHandler : ICommandHandler<EditEventCommand>
    {
        public Task<Result> Handle(EditEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
