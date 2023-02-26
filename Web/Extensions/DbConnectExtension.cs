using Infrastructure.DB.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class DbConnectExtension
    {
        public static IServiceCollection AddDbConfig(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ModsenDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
