using Hotel.Zniżka.Entities;

namespace Hotel.Test
{
    public class HotelZniżkaTest
    {
        [Fact]
        public void Test1()
        {
            var discount = new Discount
            {
                ReservationID = 1,
                DiscountPercent = 2,
                Description = "Description",
            };

            Assert.Equal(1, discount.ReservationID);
            Assert.Equal(2, discount.DiscountPercent);
            Assert.Equal("Description", discount.Description);
        }
    }
}
