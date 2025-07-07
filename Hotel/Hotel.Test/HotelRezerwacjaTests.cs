using Hotel.Rezerwacja.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Test
{
    public class HotelRezerwacjaTests
    {
        [Fact]
        public void Test1()
        {
            var reservation = new Reservation
            {
                ClientID = 1,
                Place = new List<Place>(),
                IsConfirmed = true,
                Price = 10,
            };

            Assert.Equal(1, reservation.ClientID);
            Assert.Equal(new List<Place>(), reservation.Place);
            Assert.True(reservation.IsConfirmed);
            Assert.Equal(10, reservation.Price);
        }

        [Fact]
        public void Test2()
        {
            var place = new Place
            {
                Name = "Name_1",
                Address = "Address_1",
                Desciption = "Description_1",
            };

            Assert.Equal("Name_1", place.Name);
            Assert.Equal("Address_1", place.Address);
            Assert.Equal("Description_1", place.Desciption);

        }

        [Fact]
        public void Test3()
        {
            var place1 = new Place
            {
                Name = "Name_1",
                Address = "Address_1",
                Desciption = "Description_1",
            };

            var place2 = new Place
            {
                Name = "Name_1",
                Address = "Address_1",
                Desciption = "Description_1",
            };

            var reservation = new Reservation
            {
                ClientID = 1,
                Place = new List<Place>(),
                IsConfirmed = true,
                Price = 10,
            };
            reservation.Place.Add(place1);
            reservation.Place.Add(place2);
            
            List<Place> tempPlace = new List<Place>();
            tempPlace.Add(place1);
            tempPlace.Add(place2);

            Assert.Equal(1, reservation.ClientID);
            Assert.Equal(tempPlace, reservation.Place);
            Assert.True(reservation.IsConfirmed);
            Assert.Equal(10, reservation.Price);
        }
    }
}
