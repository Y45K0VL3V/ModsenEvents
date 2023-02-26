using Application.Abstractions.Messaging;
using Application.DTO;

namespace Application.ModsenEvents.Queries.GetEvents
{
    public class GetEventsQuery : IQuery<IEnumerable<ModsenEventDTO>>
    {
    }
}
