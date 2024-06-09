using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Repo;

public interface ITripRepo
{
    Task<PaginatedResult<Trip>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10);
    Task<List<Trip>> GetAllTripsAsync();
}
