using MediatR;

namespace Event_Service.Features.Events.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventEnumResult>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? Image { get; set; }
        public Guid Space { get; set; }
    }
}
