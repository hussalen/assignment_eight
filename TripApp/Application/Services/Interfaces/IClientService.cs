using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> DeleteClient(int clientId);
    }
}
