using Hotel.Zniżka.Services;

namespace Hotel.Zniżka.Extensions
{
    public static class DiscountCollectionExtensions
    {
        public static IServiceCollection AddDiscountServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DiscountDbContext, DiscountDbContext>();
            serviceCollection.AddTransient<DiscountService>();

            return serviceCollection;
        }
    }
}
