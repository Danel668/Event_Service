using MediatR;

namespace Event_Service.Features.Events.DeleteEvent
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IEventsManager _eventsManager;
      

        public DeleteEventHandler(IEventsManager eventsManager)
        {
            _eventsManager = eventsManager;
        }

        public Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_eventsManager.DeleteEvent(request.Id));
        }
    }
}
