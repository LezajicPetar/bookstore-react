using BookstoreApplication.Dtos;
using BookstoreApplication.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [ApiController]
    [Route("api/authorization")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterAsync(RegistrationDto data)
        {
            _logger.LogInformation("HTTP POST api/authorization/registration triggered.");

            await _authService.RegisterAsync(data);

            _logger.LogInformation("HTTP POST api/authorization/registration completed.");

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto data)
        {
            _logger.LogInformation("HTTP POST api/authorization/login triggered.");

            var token = await _authService.LoginAsync(data);

            _logger.LogInformation("HTTP POST api/authorization/login completed.");

            return Ok(token);
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            return Ok(await _authService.GetProfile(User));
        }

    }
}
