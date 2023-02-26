using Application.Abstractions.Messaging;
using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Mapster;

namespace Application.ModsenEvents.Queries.GetEvents
{
    public class GetEventsQueryHandler : IQueryHandler<GetEventsQuery, IEnumerable<ModsenEventDTO>>
    {
        public GetEventsQueryHandler(IRepository<ModsenEvent> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        private readonly IRepository<ModsenEvent> _eventRepository;

        public async Task<Result<IEnumerable<ModsenEventDTO>>> Handle(GetEventsQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                var events = await _eventRepository.ListAsync(cancellationToken);
                var eventsDTO = events.Adapt<IEnumerable<ModsenEventDTO>>();

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
