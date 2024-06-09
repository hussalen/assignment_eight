using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace assignment_eight.TripApp.Infra.Repo;

public class ClientRepo : IClientRepo
{
    private readonly TripdbContext _tripDbContext;

    public ClientRepo(TripdbContext tripDbContext)
    {
        _tripDbContext = tripDbContext;
    }

    public async Task<Client> DelClient(int clientId)
    {
        await _tripDbContext.Clients.Where(c => c.IdClient == clientId).ExecuteDeleteAsync();

        return null;
    }
}
