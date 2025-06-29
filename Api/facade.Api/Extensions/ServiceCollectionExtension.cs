using facade.Core.Configs;
using facade.Core.Services.Booking;
using facade.Core.Services.Hotel;
using facade.Core.Services.Seeding;

namespace facade.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterComponents(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterConfigs(services, configuration);
            RegisterServices(services, configuration);
        }

        private static void RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiConfig>(configuration.GetSection(ApiConfig.SectionName));
        }

        private static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ISeedingService, SeedingService>();
        }
    }
}