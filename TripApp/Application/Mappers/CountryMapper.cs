using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Mappers;

public static class CountryMapper
{
    public static CountryDto MapToCountryDto(this Country country)
    {
        return new CountryDto { Name = country.Name };
    }
}
