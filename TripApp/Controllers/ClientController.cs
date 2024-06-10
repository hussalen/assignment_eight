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
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var isDeleted = await _clientservice.DeleteClient(idClient);
            if (isDeleted != false)
            {
                return Ok(isDeleted);
            }
            return NotFound($"Client {idClient} not found");
        }
    }
}
