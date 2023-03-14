namespace Event_Service.Features.Events
{
    public interface IEventsManager
    {
        public void CreateEvent(Event ev);
        public bool DeleteEvent(Guid id);
        public bool UpdateEvent(Event ev);
        public IEnumerable<Event> GetAllEvents();
        public Event? Get(Guid id);
    }
}
