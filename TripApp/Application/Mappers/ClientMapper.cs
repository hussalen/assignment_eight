using assignment_eight.TripApp.Application.DTOs;
using assignment_eight.TripApp.Core.Model;

namespace assignment_eight.TripApp.Application.Mappers;

public static class ClientMapper
{
    public static ClientDto MapToCountryDto(this Client client)
    {
        return new ClientDto { FirstName = client.FirstName, LastName = client.LastName };
    }
}
