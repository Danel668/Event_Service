using FluentValidation;
using MediatR;

namespace Event_Service.Features.Events.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, CreateEventEnumResult>
    {
        private readonly IEventsManager _eventsManager;
        private readonly IImageManager _imageManager;
        private  readonly  ISpaceManager _spaceManager;
        private readonly IValidator<CreateEventCommand> _validator;

        public CreateEventHandler(IEventsManager eventsManager, IImageManager imageManager, ISpaceManager 
            spaceManager, IValidator<CreateEventCommand> validator)
        {
            _eventsManager = eventsManager;
            _imageManager = imageManager;
            _spaceManager = spaceManager;
            _validator = validator;
        }

        public async Task<CreateEventEnumResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
           await _validator.ValidateAndThrowAsync(request, cancellationToken);

           if (request.Image != null)
           {
               if (!_imageManager.IsExist(request.Image)) return CreateEventEnumResult.ErrorImage; 
           }

           if (!_spaceManager.IsExist((request.Space))) return CreateEventEnumResult.ErrorSpace;


            var newEvent = new Event()
            {
               Id = Guid.NewGuid(),
               Start = request.Start,
               End = request.End,
               Name = request.Name,
               Description = request.Description,
               Image = request.Image,
               Space = request.Space,
            };

           _eventsManager.CreateEvent(newEvent);

           return CreateEventEnumResult.Success;
        }
    }
}
