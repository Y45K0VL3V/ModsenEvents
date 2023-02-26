using Application.Abstractions.Messaging;

namespace Application.ModsenEvents.Commands.DeleteEvent
{
    public class DeleteEventCommand : ICommand
    {
        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
