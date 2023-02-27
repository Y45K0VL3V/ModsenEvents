using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DB.Contexts;
using Infrastructure.DB.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Web.Configuration.ServiceInstallers
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<ModsenEvent>, ModsenRepository<ModsenEvent>>();

            services.AddDbContext<ModsenDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IRepository<ModsenEvent>, ModsenRepository<ModsenEvent>>();
        }
    }
}
