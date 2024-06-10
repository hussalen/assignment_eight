using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Core.Model;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace assignment_eight.TripApp.Infra.Repo;

public class AssignClientToTripRepo : IAssignClientToTripRepo
{
    private readonly TripdbContext _tripDbContext;

    public AssignClientToTripRepo(TripdbContext tripDbContext)
    {
        _tripDbContext = tripDbContext;
    }

    public async Task<List<ClientTrip>> AssignClientToTrip(int idTrip)
    {
        return null;
    }

    public async Task<List<Client>> GetClientList()
    {
        return _tripDbContext.Clients.Select(cl => cl).ToList();
    }

    public async Task<Boolean> CheckIfClientExists(string pesel)
    {
        var clist = await GetClientList();
        return _tripDbContext
            .ClientTrips.Join(
                clist,
                ct => ct.IdClient,
                client => client.IdClient,
                (ct, client) => new { ClientTrip = ct, Client = client }
            )
            .Where(ct_client => ct_client.Client.Pesel == pesel)
            .Select(ct_client => new { ct_client.Client.Pesel })
            .IsNullOrEmpty();
    }

    public async Task<Boolean> CheckIfTripDateFromIsFuturistic(int idTrip)
    {
        var trips = await GetAllTripsAsync();
        return trips
            .AsEnumerable()
            .Where(tr => tr.DateFrom >= DateTime.UtcNow && tr.IdTrip == idTrip)
            .Select(tr => tr)
            .IsNullOrEmpty();
    }

    public async Task<List<Trip>> GetAllTripsAsync()
    {
        return await _tripDbContext
            .Trips.Include(e => e.ClientTrips)
            .ThenInclude(e => e.IdClientNavigation)
            .Include(e => e.IdCountries)
            .OrderBy(e => e.DateFrom)
            .ToListAsync();
    }
}
