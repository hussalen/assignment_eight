using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Services.Interfaces
{
    public interface IAssignClientToTripService
    {
        Task<List<ClientTrip>> AddClientToTrip(
            int idTrip,
            string firstName,
            string lastName,
            string email,
            string telephone,
            string pesel
        );

        Task<Boolean> CheckIfClientExists(IEnumerable<Client> clientList, string pesel);

        Task<Boolean> CheckIfClientIsInTrip(string pesel, int idTrip);

        Task<Boolean> CheckIfTripDateFromIsFuturistic(
            IEnumerable<ClientTrip>? clientList,
            List<GetTripDto>? tripList,
            int idTrip
        );

        Task<List<GetTripDto>> GetAllTripsAsync();

        Task<IEnumerable<Client>>? GetClientList();
    }
}
