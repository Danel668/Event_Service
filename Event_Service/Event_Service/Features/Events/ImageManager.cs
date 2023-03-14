using Event_Service.Features.Events.TempStorage;

namespace Event_Service.Features.Events
{
    public class ImageManager : IImageManager
    {
        public bool IsExist(Guid? id)
        {
            var image = Storage.Images.FirstOrDefault(i => i.Id == id);
            return image != null;
        }
    }
}
