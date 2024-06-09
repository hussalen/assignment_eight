using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_eight.TripApp.Application.DTOs
{
    public class GetTripDto
    {
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required DateTime DateFrom { get; set; }
        public required DateTime DateTo { get; set; }
        public required int MaxPeople { get; set; }
        public required List<CountryDto> Countries { get; set; } = [];
        public required List<ClientDto> Clients { get; set; } = [];
    }
}
