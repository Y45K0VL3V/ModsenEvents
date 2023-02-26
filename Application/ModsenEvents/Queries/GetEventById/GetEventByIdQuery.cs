using Application.Abstractions.Messaging;
using Application.DTO;

namespace Application.ModsenEvents.Queries.GetEventById
{
    public class GetEventByIdQuery : IQuery<ModsenEventDTO>
    {
        public GetEventByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
