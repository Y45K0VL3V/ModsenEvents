using IdentityModel.Client;
using Web.Auth.Interfaces;

namespace Web.Auth.Services
{
    public class TokenService : ITokenService
    {
        public TokenService()
        {
            using (var client = new HttpClient())
            {
                _discDocument = client.GetDiscoveryDocumentAsync("https://localhost:5001/.well-known/openid-configuration").Result;
            }
        }

        private readonly DiscoveryDocumentResponse _discDocument;

        public async Task<TokenResponse> GetToken(string scope)
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = _discDocument.TokenEndpoint,
                    ClientId = "cwm.client",
                    Scope = scope,
                    ClientSecret = "ModsenSecret"
                });

                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }

                return tokenResponse;
            }
        }
    }
}
