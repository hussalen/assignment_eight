namespace assignment_eight.TripApp.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<Boolean> DeleteClient(int clientId);
    }
}
