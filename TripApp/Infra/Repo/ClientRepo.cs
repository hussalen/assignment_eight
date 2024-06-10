using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Core.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace assignment_eight.TripApp.Infra.Repo;

public class ClientRepo : IClientRepo
{
    private readonly TripdbContext _tripDbContext;

    public ClientRepo(TripdbContext tripDbContext)
    {
        _tripDbContext = tripDbContext;
    }

    public async Task<Boolean> DelClient(int clientId)
    {
        var assignedTrips = await _tripDbContext
            .ClientTrips.Where(tr => tr.IdClient == clientId)
            .ToListAsync();

        var deletedClient = await _tripDbContext
            .Clients.Where(c => c.IdClient == clientId)
            .ExecuteDeleteAsync();

        return assignedTrips != null && deletedClient != 0;
    }
}
