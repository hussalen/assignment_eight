using assignment_eight.TripApp.Application.Services.Interfaces;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientService _clientRepo;

    public ClientService(IClientService clientRepo)
    {
        _clientRepo = clientRepo;
    }

    public async Task<Client> DeleteClient()
    {
        var delete = await _clientRepo.DeleteClient();
        //Logic to be added here.
        return delete;
    }
}
