using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Mappers;

public static class TripMapper
{
    public static GetTripDto MapToGetTripDto(this Trip trip)
    {
        return new GetTripDto
        {
            Name = trip.Name,
            DateFrom = trip.DateFrom,
            DateTo = trip.DateTo,
            Description = trip.Description,
            MaxPeople = trip.MaxPeople,
            Countries = trip.IdCountries.Select(country => country.MapToCountryDto()).ToList(),
            Clients = trip.ClientTrips.Select(e => e.IdClientNavigation.MapToCountryDto()).ToList()
        };
    }
}
