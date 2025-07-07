using Hotel.Rezerwacja.Entities;
using Hotel.Rezerwacja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Rezerwacja.Controllers
{
    public class PlaceController : ControllerBase
    {
        private readonly PlaceService _placeService;

        public PlaceController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("api/places")]
        public async Task<IEnumerable<Place>> Read() => await _placeService.Get();

        [HttpGet("api/places/{ID}")]
        public async Task<IActionResult> ReadByID(int ID)
        {
            var Place = await _placeService.GetByID(ID);

            if (Place == null)
            {
                return NotFound($"Nie ma lokalizacji o ID: {ID}");
            }
            return Ok(Place);
        }

        [HttpPost("api/places")]
        public async Task<IActionResult> Create([FromBody] Place dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _placeService.Add(dto);
            return Ok();
        }

        [HttpPut("api/places/{ID}")]
        public async Task<IActionResult> Update(int ID, [FromBody] Place place)
        {
            if (ID != place.ID)
            {
                return BadRequest("Podane ID nie zgadza się z ID znajdującym się w treści żądania.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    

            var Success = await _placeService.Update(place);
            if (!Success)
            {
                return NotFound($"Nie ma lokalizacji o ID: {ID}.");
            }

            return NoContent();
        }

        [HttpDelete("api/places/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var Success = await _placeService.Delete(ID);
            if (!Success)
            {
                return NotFound($"Nie ma lokalizacji o ID: {ID}");
            }

            return NoContent();
        }
    }
}
