using IdentityModel.Client;

namespace Web.Auth.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
