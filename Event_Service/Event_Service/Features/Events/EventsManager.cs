using Event_Service.Features.Events.TempStorage;

namespace Event_Service.Features.Events
{
    public class EventsManager : IEventsManager
    {
        public void CreateEvent(Event ev) 
        {
            Storage.Events.Add(ev);
        }

        public bool DeleteEvent(Guid id)
        {
            var ev = Storage.Events.FirstOrDefault(e => e.Id == id);
            if (ev == null) return false;
            Storage.Events.Remove(ev);
            return true;
        }

        public bool UpdateEvent(Event ev)
        {
            var _event = Storage.Events.FirstOrDefault(e => e.Id == ev.Id);
            if (_event == null) return false;
            Storage.Events.Remove(_event);
            Storage.Events.Add(ev);
            return true;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return Storage.Events;
        }

        public Event? Get(Guid id)
        {
            return Storage.Events.FirstOrDefault(ev => ev.Id == id);
        }


    }
}
