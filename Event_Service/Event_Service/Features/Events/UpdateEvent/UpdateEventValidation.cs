using FluentValidation;
namespace Event_Service.Features.Events.UpdateEvent
{
    public class UpdateEventValidation : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventValidation()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
            RuleFor(d => d.Description).NotNull().NotEmpty();
            RuleFor(s => s.Start).NotNull().NotEmpty();
            RuleFor(e => e.End).NotNull().NotEmpty();
            RuleFor(s => s.Space).NotNull().NotEmpty();
            RuleFor(s => s.Start).LessThan(e => e.End)
                .WithMessage("The start date must be earlier than the end date.");
        }
    }
}
