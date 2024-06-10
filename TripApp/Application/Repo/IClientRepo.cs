namespace assignment_eight.TripApp.Application.Repo;

public interface IClientRepo
{
    Task<Boolean> DelClient(int clientId);
}
