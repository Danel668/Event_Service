using MediatR;

namespace Event_Service.Features.Events.GetAllEvents
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsCommand, List<Event>>
    {
        private readonly IEventsManager _eventsManager;
        public GetAllEventsHandler(IEventsManager eventManager)
        {
            _eventsManager = eventManager;
        }

        public Task<List<Event>> Handle(GetAllEventsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eventsManager.GetAllEvents().ToList());
        }
    }
}
