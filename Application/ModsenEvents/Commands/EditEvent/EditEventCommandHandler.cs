using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Mapster;
using MapsterMapper;

namespace Application.ModsenEvents.Commands.EditEvent
{
    public class EditEventCommandHandler : ICommandHandler<EditEventCommand>
    {
        public EditEventCommandHandler(IMapper mapper, IRepository<ModsenEvent> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        private readonly IMapper _mapper;
        private readonly IRepository<ModsenEvent> _eventRepository;

        public async Task<Result> Handle(EditEventCommand request, CancellationToken cancellationToken = default)
        {
            ModsenEvent modsenEvent = _mapper.Map<ModsenEvent>(request.EventDTO);
            try
            {
                await _eventRepository.EditAsync(modsenEvent, cancellationToken);
                return Result.Success();
            }
            catch
            {
                return Result.Failure(new("Event.EditFailure", $"Can't edit event {modsenEvent?.Id}."));
            }
        }
    }
}
