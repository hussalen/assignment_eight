using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Application.Services.Interfaces;
using assignment_eight.TripApp.Core.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace assignment_eight.TripApp.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepo _clientRepo;

    public ClientService(IClientRepo clientRepo)
    {
        _clientRepo = clientRepo;
    }

    public async Task<Boolean> DeleteClient(int clientId)
    {
        return await _clientRepo.DelClient(clientId);
    }
}
