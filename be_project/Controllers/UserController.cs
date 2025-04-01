using be_project.Models;
using be_project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                // Gọi Service để xử lý logic
                var newUser = await _authService.AddUserAsync(userDto);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
