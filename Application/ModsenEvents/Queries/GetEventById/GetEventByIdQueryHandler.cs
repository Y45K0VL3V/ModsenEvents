using Application.Abstractions.Messaging;
using Application.DTO;
using Domain.Shared;

namespace Application.ModsenEvents.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IQueryHandler<GetEventByIdQuery, ModsenEventDTO>
    {
        public Task<Result<ModsenEventDTO>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
