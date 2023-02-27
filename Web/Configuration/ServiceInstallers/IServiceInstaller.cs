namespace Web.Configuration.ServiceInstallers
{
    public interface IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration);
    }
}
