using Event_Service.Features.Events;
using Event_Service.Features.Events.CreateEvent;
using Event_Service.Features.Events.UpdateEvent;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

namespace Event_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation();

            builder.Services.AddTransient<IValidator<CreateEventCommand>, CreateEventValidation>();
            builder.Services.AddTransient<IValidator<UpdateEventCommand>, UpdateEventValidation>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(typeof(Program));

            builder.Services.AddTransient<IEventsManager, EventsManager>();
            builder.Services.AddTransient<IImageManager, ImageManager>();
            builder.Services.AddTransient<ISpaceManager, SpaceManager>();


            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}