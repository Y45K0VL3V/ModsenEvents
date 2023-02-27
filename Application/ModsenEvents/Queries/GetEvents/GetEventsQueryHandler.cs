using Application.Abstractions.Messaging;
using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Mapster;
using MapsterMapper;
using System.Collections.Generic;

namespace Application.ModsenEvents.Queries.GetEvents
{
    public class GetEventsQueryHandler : IQueryHandler<GetEventsQuery, IEnumerable<ModsenEventDTO>>
    {
        public GetEventsQueryHandler(IMapper mapper, IRepository<ModsenEvent> eventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        private readonly IRepository<ModsenEvent> _eventRepository;
        private readonly IMapper _mapper;

        public async Task<Result<IEnumerable<ModsenEventDTO>>> Handle(GetEventsQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                var events = await _eventRepository.ListAsync(cancellationToken);
                var eventsDTO = _mapper.Map<IEnumerable<ModsenEventDTO>>(events);

                if (eventsDTO is not null)
                {
                    return Result.Success(eventsDTO);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return Result.Failure<IEnumerable<ModsenEventDTO>>(new("Event.GetFailure", $"Events not found"));
            }
        }
    }
}
