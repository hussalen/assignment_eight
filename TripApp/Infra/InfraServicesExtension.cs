using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Controllers;
using assignment_eight.TripApp.Infra;
using assignment_eight.TripApp.Infra.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace assignment_eight.TripApp.Infra;

public static class InfrastructureServicesExtension
{
    public static void RegisterInfraServices(this IServiceCollection app)
    {
        app.AddScoped<ITripRepo, TripRepo>();
        app.AddScoped<IClientRepo, ClientRepo>();
        app.AddScoped<IAssignClientToTripRepo, AssignClientToTripRepo>();
        app.AddDbContext<TripdbContext>();
    }
}
