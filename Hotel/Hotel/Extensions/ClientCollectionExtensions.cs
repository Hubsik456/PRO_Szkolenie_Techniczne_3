using Hotel.Services;

namespace Hotel.Extensions
{
    public static class ClientCollectionExtensions
    {
        public static IServiceCollection AddClientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ClientDbContext, ClientDbContext>();
            serviceCollection.AddTransient<ClientService>();

            return serviceCollection;
        }
    }
}
