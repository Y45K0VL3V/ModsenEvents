using Application.Abstractions.Messaging;
using Application.DTO;

namespace Application.ModsenEvents.Commands.EditEvent
{
    public class EditEventCommand : ICommand
    {
        public EditEventCommand(ModsenEventDTO eventDTO)
        {
            EventDTO = eventDTO;
        }

        public ModsenEventDTO EventDTO { get; }
    }
}
