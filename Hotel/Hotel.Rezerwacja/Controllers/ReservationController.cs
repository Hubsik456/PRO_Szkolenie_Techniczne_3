using Hotel.Rezerwacja.Entities;
using Hotel.Rezerwacja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Rezerwacja.Controllers
{
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("api/reservations")]
        public async Task<IEnumerable<Reservation>> Read() => await _reservationService.Get();

        [HttpGet("api/reservations/{ID}")]
        public async Task<IActionResult> ReadByID(int ID)
        {
            var Reservation = await _reservationService.GetByID(ID);

            if (Reservation == null)
            {
                return NotFound($"Nie ma rezerwacji o ID: {ID}");
            }
            return Ok(Reservation);
        }

        [HttpPost("api/reservations")]
        public async Task<IActionResult> Create([FromBody] Reservation dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _reservationService.Add(dto);
            return Ok();
        }

        [HttpPut("api/reservation/{ID}")]
        public async Task<IActionResult> Update(int ID, [FromBody] Reservation reservation)
        {
            if (ID != reservation.ID)
            {
                return BadRequest("Podane ID nie zgadza się z ID znajdującym się w treści żądania.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Success = await _reservationService.Update(reservation);
            if (!Success)
            {
                return NotFound($"Nie ma rezerwacji o ID: {ID}");
            }

            return NoContent();
        }

        [HttpDelete("api/reservation/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var Success = await _reservationService.Delete(ID);
            if (!Success)
            {
                return NotFound($"Nie ma rezerwacji o ID: {ID}.");
            }

            return NoContent();
        }
    }
}
