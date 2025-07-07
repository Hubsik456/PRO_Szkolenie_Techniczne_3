using Hotel.Zniżka.Entities;
using Hotel.Zniżka.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Zniżka.Controllers
{
    public class DiscountController : ControllerBase
    {
        private readonly DiscountService _discountService;

        public DiscountController(DiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("api/discounts")]
        public async Task<IEnumerable<Discount>> Read() => await _discountService.Get();

        [HttpGet("api/discounts/{ID}")]
        public async Task<IActionResult> ReadById(int ID)
        {
            var discountDto = await _discountService.GetById(ID);

            if (discountDto == null)
            {
                return NotFound();
            }

            return Ok(discountDto);
        }

        [HttpPost("api/discounts")]
        public async Task<IActionResult> Create([FromBody] Discount dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _discountService.Add(dto);
            return Ok();
        }

        [HttpPut("api/discounts/{ID}")]
        public async Task<IActionResult> Update(int ID, [FromBody] Discount discount)
        {
            if (ID != discount.ID)
            {
                return BadRequest("Podane ID nie zgadza się z ID znajdującym się w treści żądania.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Success = await _discountService.Update(discount);
            if (!Success)
            {
                return NotFound($"Nie ma zniżki o ID: {ID}.");
            }

            return NoContent();
        }

        [HttpDelete("api/discounts/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var Success = await _discountService.Delete(ID);
            if (!Success)
            {
                return NotFound($"Nie ma zniżki o ID: {ID}.");
            }

            return NoContent();
        }
    }
}
