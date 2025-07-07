using Hotel.Rezerwacja.Services;

namespace Hotel.Rezerwacja.Extensions
{
    public static class ReservationCollectionExtensions
    {
        public static IServiceCollection AddReservationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ReservationDbContext, ReservationDbContext>();
            serviceCollection.AddTransient<ReservationService>();
            serviceCollection.AddTransient<PlaceService>();
            return serviceCollection;
        }
    }
}
