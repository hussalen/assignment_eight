using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Repo;

public interface IAssignClientToTripRepo
{
    Task<List<ClientTrip>> AssignClientToTrip(int idTrip);
    Task<List<Client>> GetClientList();

    Task<Boolean> CheckIfClientExists(string pesel);
    Task<Boolean> CheckIfTripDateFromIsFuturistic(int idTrip);

    Task<List<Trip>> GetAllTripsAsync();
}
