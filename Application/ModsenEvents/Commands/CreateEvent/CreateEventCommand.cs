using Application.Abstractions.Messaging;
using Application.DTO;

namespace Application.ModsenEvents.Commands.CreateEvent
{
    public class CreateEventCommand : ICommand
    {
        public CreateEventCommand(ModsenEventDTO eventDTO) 
        {
            eventDTO.Id = Guid.Empty;
            EventDTO = eventDTO;
        }

        public ModsenEventDTO EventDTO { get; }
    }

}
