using Application.Abstractions.Messaging;
using Application.ModsenEvents.Commands.CreateEvent;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using MapsterMapper;

namespace Application.ModsenEvents.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : ICommandHandler<DeleteEventCommand>
    {
        public DeleteEventCommandHandler(IRepository<ModsenEvent> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        private readonly IRepository<ModsenEvent> _eventRepository;

        public async Task<Result> Handle(DeleteEventCommand request, CancellationToken cancellationToken = default)
        {
            Guid id = request.Id;
            try
            {
                await _eventRepository.DeleteAsync(id, cancellationToken);
                return Result.Success();
            }
            catch
            {
                return Result.Failure(new("Event.DeleteFailure", $"Can't delete event {id}."));
            }
        }
    }
}
