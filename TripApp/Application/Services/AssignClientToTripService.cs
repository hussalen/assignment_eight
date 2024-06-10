using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Application.Mappers;
using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Application.Services.Interfaces;
using assignment_eight.TripApp.Core.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace assignment_eight.TripApp.Application.Services;

public class AssignClientToTripService : IAssignClientToTripService
{
    private readonly IAssignClientToTripRepo _assignClientToTripRepo;

    public AssignClientToTripService(IAssignClientToTripRepo assignClientToTripRepo)
    {
        _assignClientToTripRepo = assignClientToTripRepo;
    }

    public async Task<List<ClientTrip>> AddClientToTrip(
        int idTrip,
        string firstName,
        string lastName,
        string email,
        string telephone,
        string pesel
    )
    {
        return await _assignClientToTripRepo.AssignClientToTrip(idTrip);
    }

    public async Task<Boolean> CheckIfClientExists(IEnumerable<Client> clientList, string pesel)
    {
        var chk = await _assignClientToTripRepo.CheckIfClientExists(pesel);
        return clientList
            .Where(client => client.Pesel == pesel)
            .Select(client => client)
            .IsNullOrEmpty();
    }

    public async Task<Boolean> CheckIfClientIsInTrip(string pesel, int idTrip)
    {
        foreach (var tr in await _assignClientToTripRepo.GetAllTripsAsync())
        {
            if (tr.IdTrip == idTrip)
            {
                return !await _assignClientToTripRepo.CheckIfClientExists(pesel);
            }
        }
        return false;
    }

    public async Task<Boolean> CheckIfTripDateFromIsFuturistic(
        IEnumerable<ClientTrip>? clientTrips,
        List<GetTripDto> tripList,
        int idTrip
    )
    {
        var chk = await _assignClientToTripRepo.CheckIfTripDateFromIsFuturistic(idTrip);
        var tripExists =
            clientTrips
                .Where(ct => ct.IdTrip == idTrip)
                .Select(ct_client => ct_client)
                .IsNullOrEmpty()
            && tripList
                .Where(tl => tl.DateFrom >= DateTime.UtcNow)
                .Select(tl => tl)
                .IsNullOrEmpty();
        return tripExists;
    }

    public async Task<List<GetTripDto>> GetAllTripsAsync()
    {
        var trips = await _assignClientToTripRepo.GetAllTripsAsync();
        var mappedTrips = trips.Select(trip => trip.MapToGetTripDto()).ToList();
        return mappedTrips;
    }

    public async Task<IEnumerable<Client>?> GetClientList()
    {
        return await _assignClientToTripRepo.GetClientList();
    }
}
