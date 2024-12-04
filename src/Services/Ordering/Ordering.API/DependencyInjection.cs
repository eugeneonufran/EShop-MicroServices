namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddCarter();
            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;

        }

        public static WebApplication UseApiServices(this WebApplication webApplication)
        {
            webApplication.MapCarter();
            webApplication.UseExceptionHandler(options => { });

            return webApplication;
        }
    }
}
