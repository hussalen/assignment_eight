using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Repo;

public interface IClientRepo
{
    Task<Client> DelClient(int clientId);
}
