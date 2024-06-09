using assignment_eight.TripApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace assignment_eight.TripApp.Controllers
{
    [ApiController]
    [Route("/api/clients/{idClient}")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientservice;

        public ClientController(IClientService clientservice)
        {
            _clientservice = clientservice;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient([FromHeader] int clientId)
        {
            return Ok(await _clientservice.DeleteClient(clientId));
        }
    }
}
