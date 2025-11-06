using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace BookstoreApplication.Service
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(
            IMapper mapper,
            ILogger<AuthService> logger,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task RegisterAsync(RegistrationDto data)
        {
            _logger.LogInformation("Starting user registration for username: {Username}.", data.Username);

            var user = _mapper.Map<ApplicationUser>(data);
            var result = await _userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                string errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                _logger.LogWarning("User registration failed for {Username}. Errors: {Errors}.", data.Username, errorMessage);
                throw new BadRequestException(errorMessage);
            }

            _logger.LogInformation("User {Username} registered successfully with Id {UserId}.", user.UserName, user.Id);
        }

        public async Task LoginAsync(LoginDto data)
        {
            _logger.LogInformation("Login attempt for username: {Username}.", data.Username);

            var user = await _userManager.FindByNameAsync(data.Username)
                ?? throw new BadRequestException("Invalid username.");

            var passwordMatch = await _userManager.CheckPasswordAsync(user, data.Password);

            if (!passwordMatch) throw new BadRequestException("Invalid password.");

            _logger.LogInformation("User {Username} logged in successfully.", data.Username);
        }
    }
}
