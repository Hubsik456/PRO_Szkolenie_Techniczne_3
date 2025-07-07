using Hotel.Entities;

namespace Hotel.Test
{
    public class HotelTests
    {
        [Fact]
        public void Test1()
        {
            var client = new Client
            {
                FirstName = "FN_1",
                LastName = "LN_1",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
                Email = "WIP_1@WIP_1.com",
            };

            Assert.Equal("FN_1", client.FirstName);
            Assert.Equal("LN_1", client.LastName);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now), client.DateOfBirth);
            Assert.Equal("WIP_1@WIP_1.com", client.Email);
        }
    }
}