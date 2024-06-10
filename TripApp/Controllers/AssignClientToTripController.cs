using assignment_eight.TripApp.Application.Services.Interfaces;
using assignment_eight.TripApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace assignment_eight.TripApp.Controllers
{
    [ApiController]
    [Route("/api/trips/{idTrip}/clients")]
    public class AssignClientToTripController : ControllerBase
    {
        private readonly IAssignClientToTripService _assignClientToTripService;

        public AssignClientToTripController(IAssignClientToTripService assignClientToTripService)
        {
            _assignClientToTripService = assignClientToTripService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClientToTrip(
            int idTrip,
            AssignClientRecord assignClientRecord
        )
        {
            var tripAssigned = await _assignClientToTripService.AddClientToTrip(
                idTrip,
                assignClientRecord.FirstName,
                assignClientRecord.LastName,
                assignClientRecord.Email,
                assignClientRecord.Telephone,
                assignClientRecord.Pesel
            );

            var cl = await _assignClientToTripService.GetClientList();
            if (await _assignClientToTripService.CheckIfClientExists(cl, assignClientRecord.Pesel))
            {
                return ValidationProblem(
                    $"Client with pesel {assignClientRecord.Pesel} already exists."
                );
            }

            if (
                await _assignClientToTripService.CheckIfClientIsInTrip(
                    assignClientRecord.Pesel,
                    idTrip
                )
            )
            {
                return ValidationProblem(
                    $"Client with pesel {assignClientRecord.Pesel} and Trip ID {idTrip} already exists."
                );
            }

            if (
                await _assignClientToTripService.CheckIfTripDateFromIsFuturistic(
                    tripAssigned,
                    await _assignClientToTripService.GetAllTripsAsync(),
                    idTrip
                )
            )
            {
                return ValidationProblem($"Trip ID {idTrip} is already registered.");
            }
            if (tripAssigned != null)
            {
                return Ok(tripAssigned);
            }
            return NotFound($"Client {idTrip} missing");
        }
    }
}
