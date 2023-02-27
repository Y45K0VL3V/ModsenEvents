using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Mapster;
using MapsterMapper;

namespace Application.ModsenEvents.Commands.CreateEvent
{
    public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand>
    {
        public CreateEventCommandHandler(IMapper mapper, IRepository<ModsenEvent> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        private readonly IMapper _mapper;
        private readonly IRepository<ModsenEvent> _eventRepository;

        public async Task<Result> Handle(CreateEventCommand request, CancellationToken cancellationToken = default)
        {
            ModsenEvent modsenEvent = _mapper.Map<ModsenEvent>(request.EventDTO);
            try
            {
                await _eventRepository.AddAsync(modsenEvent, cancellationToken);
                return Result.Success();
            }
            catch
            {
                return Result.Failure(new("Event.CreateFailure", "Can't create event with given parameters"));
            }
        }
    }
}
