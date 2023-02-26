using Application.Abstractions.Messaging;
using Application.DTO;
using Domain.Shared;

namespace Application.ModsenEvents.Queries.GetEvents
{
    public class GetEventsCommandHandler : IQueryHandler<GetEventsCommand, IEnumerable<ModsenEventDTO>>
    {
        public Task<Result<IEnumerable<ModsenEventDTO>>> Handle(GetEventsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
