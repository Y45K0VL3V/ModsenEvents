using Application.DTO;
using Application.ModsenEvents.Commands.CreateEvent;
using Application.ModsenEvents.Commands.DeleteEvent;
using Application.ModsenEvents.Commands.EditEvent;
using Application.ModsenEvents.Queries.GetEventById;
using Application.ModsenEvents.Queries.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize]
    public class EventsController : ControllerBase
    {
        public EventsController(ISender sender)
        {
            _sender = sender;
        }

        private readonly ISender _sender;

        [HttpGet("{eventId:guid}")]
        [ProducesResponseType(typeof(ModsenEventDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetEventById(Guid eventId, CancellationToken token)
        {
            var query = new GetEventByIdQuery(eventId);
            var result = await _sender.Send(query, token);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ModsenEventDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetEvents(CancellationToken token)
        {
            var query = new GetEventsQuery();
            var result = await _sender.Send(query, token);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEvent([FromBody] ModsenEventDTO eventDTO, CancellationToken token)
        {
            var query = new CreateEventCommand(eventDTO);
            var result = await _sender.Send(query, token);

            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpPut("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditEvent([FromBody] ModsenEventDTO eventDTO, CancellationToken token)
        {
            var query = new EditEventCommand(eventDTO);
            var result = await _sender.Send(query, token);

            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpDelete("delete/{eventId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEvent(Guid eventId, CancellationToken token)
        {
            var query = new DeleteEventCommand(eventId);
            var result = await _sender.Send(query, token);

            return result.IsSuccess ? Ok(result) : BadRequest();
        }
    }
}
