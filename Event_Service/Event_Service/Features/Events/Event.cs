using Swashbuckle.AspNetCore.Annotations;

namespace Event_Service.Features.Events
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? Image { get; set; }
        public Guid Space { get; set; }
    }
}
