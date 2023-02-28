using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Web.Auth.Identity
{
    public class IdentityConfiguration
    {

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1111",
                    Username = "modsen",
                    Password = "modsen",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "ModsenUser")
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("ModsenEvents.read"),
                new ApiScope("ModsenEvents.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("ModsenEvents")
                {
                    Scopes = new List<string>{ "ModsenEvents.read", "ModsenEvents.write" },
                    ApiSecrets = new List<Secret>{ new Secret("ModsenSecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ModsenSecret".Sha256()) },
                    AllowedScopes = { "ModsenEvents.read" }
                },
            };
    }
}
