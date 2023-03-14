using MediatR;

namespace Event_Service.Features.Events.DeleteEvent
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
