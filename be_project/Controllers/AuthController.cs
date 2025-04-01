using be_project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        public AuthController(IAuthService userService, IConfiguration configuration, System.Net.Http.IHttpClientFactory httpClientFactory, IAuthService authService)
        {
            _userService = userService;
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _authService = authService;
        }
        [HttpGet("login/google")]
        public IActionResult LoginWithGoogle()
        {
            var url = _authService.LoginWithGoogleAsync().Result;
            return Ok(new { url });
        }
        [HttpGet("login/google/callback")]
        public async Task<IActionResult> GoogleCallback(string code)
        {
            try
            {
                var tokenResponse = await _authService.GetTokenFromGoogle(code);
                var user = await _authService.GetUserFromGoogleAsync(tokenResponse.IdToken);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the callback: {ex.Message}");
            }
        }
    }
}
