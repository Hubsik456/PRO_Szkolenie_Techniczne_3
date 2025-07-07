using Hotel.Entities;
using Hotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("clients")]
        public async Task<IEnumerable<Client>> Read() => await _clientService.Get();

        [HttpGet("clients/{ID}")]
        public async Task<IActionResult> ReadById(int ID)
        {
            var clientDto = await _clientService.GetById(ID);

            if (clientDto == null)
            {
                return NotFound();
            }

            return Ok(clientDto);
        }

        [HttpPost("clients")]
        public async Task<IActionResult> Create([FromBody] Client dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientService.Add(dto);
            return Ok();
        }

        [HttpPut("clients/{ID}")]
        public async Task<IActionResult> Update(int ID, [FromBody] Client client)
        {
            if (ID != client.ID) // Podane ID nie zgadza się z ID znajdującym się w treści żądania.
            {
                return BadRequest("Podane ID nie zgadza się z ID znajdującym się w treści żądania.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Success = await _clientService.Update(client);
            if (!Success)
            {
                return NotFound($"Nie ma klienta o ID: {ID}.");
            }

            return NoContent();
        }

        [HttpDelete("clients/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var Success = await _clientService.Delete(ID);
            if (!Success)
            {
                return NotFound($"Nie ma klienta o ID: {ID}.");
            }

            return NoContent();
        }
    }
}
