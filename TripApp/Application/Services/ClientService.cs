using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Application.Services.Interfaces;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepo _clientRepo;

    public ClientService(IClientRepo clientRepo)
    {
        _clientRepo = clientRepo;
    }

    public async Task<Client> DeleteClient(int clientId)
    {
        var delete = await _clientRepo.DelClient(clientId);
        //Logic to be added here.
        return delete;
    }
}
