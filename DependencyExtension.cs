using DependencyStore.DataProviders.Repositories.Contracts;
using DependencyStore.DataProviders.Repositories;
using DependencyStore.DataProviders.Services.Contracts;
using DependencyStore.DataProviders.Services;
using Microsoft.Data.SqlClient;

namespace DependencyStore
{
    public static class DependencyExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(x =>
                            new SqlConnection(""));
            services.AddSingleton<Configuration>();
            services.AddTransient<ICustumerRepository, CustumerRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
            
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

        }
    }
}
