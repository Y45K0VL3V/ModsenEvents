namespace Web.Configuration.ServiceInstallers
{
    public class AuthenticationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication("Bearer", options =>
                    {
                        options.ApiName = "ModsenEvents";
                        options.Authority = "https://localhost:5001";
                    }); 
        }
    }
}
