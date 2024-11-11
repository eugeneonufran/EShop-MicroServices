using Microsoft.Extensions.Configuration;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.AddInterceptors(new AuditableEntityInterceptor());
                opts.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
