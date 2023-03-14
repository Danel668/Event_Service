using Event_Service.Features.Events.CreateEvent;
using Event_Service.Features.Events.DeleteEvent;
using Event_Service.Features.Events.GetAllEvents;
using Event_Service.Features.Events.UpdateEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Event_Service.Features.Events
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventCommand command)
        {
            var ans = await _mediator.Send(command);

            if (ans == CreateEventEnumResult.ErrorImage)
                return BadRequest("This image does not exist");
            if (ans == CreateEventEnumResult.ErrorSpace)
                return BadRequest("This space does not exist");

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var events = await _mediator.Send(new GetAllEventsCommand());

            return Ok(events);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var ans = await _mediator.Send(new DeleteEventCommand { Id = id });

            if (ans) return Ok();

            return BadRequest("This event does not exist");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventCommand command)
        {
            if (id != command.Id) return BadRequest("This id does not match event id");

            var ans = await _mediator.Send(command);

            if (ans == UpdateEventEnumResult.ErrorEvent) return BadRequest("This event does not exist");
            if (ans == UpdateEventEnumResult.ErrorSpace) return BadRequest("This space does not exist");
            if (ans == UpdateEventEnumResult.ErrorImage) return BadRequest("This image does not exist");

            return Ok();
        }
    }
}
