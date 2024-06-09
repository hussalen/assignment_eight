using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Application.Mappers;
using assignment_eight.TripApp.Application.Repo;
using assignment_eight.TripApp.Application.Services.Interfaces;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Services;

public class TripService : ITripService
{
    private readonly ITripRepo _tripRepository;

    public TripService(ITripRepo tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<PaginatedResult<GetTripDto>> GetPaginatedTripsAsync(
        int page = 1,
        int pageSize = 10
    )
    {
        if (page < 1)
            page = 1;
        if (pageSize < 10)
            page = 10;
        var result = await _tripRepository.GetPaginatedTripsAsync(page, pageSize);

        var mappedTrips = new PaginatedResult<GetTripDto>
        {
            AllPages = result.AllPages,
            Data = result.Data.Select(trip => trip.MapToGetTripDto()).ToList(),
            PageNum = result.PageNum,
            PageSize = result.PageSize
        };

        return mappedTrips;
    }

    public async Task<List<GetTripDto>> GetAllTripsAsync()
    {
        var trips = await _tripRepository.GetAllTripsAsync();
        var mappedTrips = trips.Select(trip => trip.MapToGetTripDto()).ToList();
        return mappedTrips;
    }
}
