using Event_Service.Features.Events.TempStorage;

namespace Event_Service.Features.Events
{
    public class SpaceManager : ISpaceManager
    {
        public bool IsExist(Guid id)
        {
            var space = Storage.Spaces.FirstOrDefault(s => s.Id == id);
            return space != null;
        }
    }
}
