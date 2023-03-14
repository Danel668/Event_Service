using System.IO.IsolatedStorage;

namespace Event_Service.Features.Events.TempStorage
{
    public class Storage
    {
        private static List<Event>? _events;
        private static List<Image>? _images = new List<Image>()
        {
            new Image() {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")},
        };

        private static List<Space>? _spaces = new List<Space>()
        {
            new Space() {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")},
        };

        public static List<Event> Events
        {
            get
            {
                _events ??= new List<Event>();
                return _events; 
            }
        }

        public static List<Image> Images
        {
            get
            {
                _images ??= new List<Image>();
                return _images;
            }
        }

        public static List<Space> Spaces
        {
            get
            {
                _spaces ??= new List<Space>();
                return _spaces;
            }
        }
    }
}
