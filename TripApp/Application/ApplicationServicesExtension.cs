using assignment_eight.TripApp.Application.Services;
using assignment_eight.TripApp.Application.Services.Interfaces;

namespace assignment_eight.TripApp.Application;

public static class ApplicationServicesExtension
{
    public static void RegisterApplicationServices(this IServiceCollection app)
    {
        app.AddScoped<ITripService, TripService>();
        app.AddScoped<IClientService, ClientService>();
    }
}
