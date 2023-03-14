using Event_Service.Features.Events.CreateEvent;
using FluentValidation;
using MediatR;

namespace Event_Service.Features.Events.UpdateEvent
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, UpdateEventEnumResult>
    {
        private readonly IEventsManager _eventsManager;
        private readonly IImageManager _imageManager;
        private readonly ISpaceManager _spaceManager;
        private readonly IValidator<UpdateEventCommand> _validator;
        public UpdateEventHandler(IEventsManager eventsManager, IImageManager imageManager,
            ISpaceManager spaceManager, IValidator<UpdateEventCommand> validator)
        {
            _eventsManager = eventsManager;
            _imageManager = imageManager;
            _spaceManager = spaceManager;
            _validator = validator;
        }

        public async Task<UpdateEventEnumResult> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            if (request.Image != null)
            {
                if (!_imageManager.IsExist(request.Image)) return UpdateEventEnumResult.ErrorImage;
            }

            if (!_spaceManager.IsExist(request.Space)) return UpdateEventEnumResult.ErrorSpace;

            var newEvent = new Event()
            {
                Id = request.Id,
                Start = request.Start,
                End = request.End,
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                Space = request.Space,
            };

            return _eventsManager.UpdateEvent(newEvent) == true ? UpdateEventEnumResult.Success : UpdateEventEnumResult.ErrorEvent;
        }
    }
}
