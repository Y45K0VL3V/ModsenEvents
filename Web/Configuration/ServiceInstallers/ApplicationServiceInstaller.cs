using Mapster;
using MapsterMapper;
using MediatR;
using System.Reflection;

namespace Web.Configuration.ServiceInstallers
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Application.AssemblyReference.Assembly);
            services.AddSingleton(GetConfiguredMappingConfig());
            services.AddScoped<IMapper, ServiceMapper>();
        }

        private TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var cfg = TypeAdapterConfig.GlobalSettings;
            cfg.Scan(Assembly.GetExecutingAssembly(), Application.AssemblyReference.Assembly);
            return cfg;
        }
    }
}
