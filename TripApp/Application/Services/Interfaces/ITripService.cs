using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Services.Interfaces
{
    public interface ITripService
    {
        Task<PaginatedResult<GetTripDto>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10);
        Task<List<GetTripDto>> GetAllTripsAsync();
    }
}
