using Application.Abstractions.Messaging;
using Application.DTO;
using Application.ModsenEvents.Commands.CreateEvent;
using Application.Specifications;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Mapster;
using MapsterMapper;

namespace Application.ModsenEvents.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IQueryHandler<GetEventByIdQuery, ModsenEventDTO>
    {
        public GetEventByIdQueryHandler(IMapper mapper, IRepository<ModsenEvent> eventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        private readonly IRepository<ModsenEvent> _eventRepository;
        private readonly IMapper _mapper;

        public async Task<Result<ModsenEventDTO>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken = default)
        {
            Guid id = request.Id;
            var spec = new EntityByIdSpecification<ModsenEvent>(id);

            try
            {
                var events = await _eventRepository.ListAsync(spec, cancellationToken);
                var eventDTO = _mapper.Map<ModsenEventDTO>(events?.FirstOrDefault());

                if (eventDTO is not null)
                {
                    return Result.Success(eventDTO);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return Result.Failure<ModsenEventDTO>(new("Event.FindFailure", $"Event with id {id} not found"));
            }
        }
    }
}
