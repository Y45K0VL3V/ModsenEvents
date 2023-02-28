using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Auth.Interfaces;

namespace Web.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        private readonly ITokenService _tokenService;

        [HttpGet()]
        public async Task<ActionResult> Login(CancellationToken token)
        {
            var authToken = await _tokenService.GetToken("ModsenEvents.ultimate");
            return authToken is null ? NotFound() : Ok(authToken.AccessToken);
        }
    }
}
