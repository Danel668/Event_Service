using MediatR;

namespace Event_Service.Features.Events.GetAllEvents
{
    public class GetAllEventsCommand : IRequest<List<Event>>
    {
    }
}
