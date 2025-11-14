using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookstoreApplication.Service
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;

        public AuthService(
            IMapper mapper,
            ILogger<AuthService> logger,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
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

        public async Task<string> LoginAsync(LoginDto data)
        {
            _logger.LogInformation("Login attempt for username: {Username}.", data.Username);

            var user = await _userManager.FindByNameAsync(data.Username)
                ?? throw new BadRequestException("Invalid username.");

            var passwordMatch = await _userManager.CheckPasswordAsync(user, data.Password);

            if (!passwordMatch) throw new BadRequestException("Invalid password.");

            _logger.LogInformation("User {Username} logged in successfully.", data.Username);

            var token = GenerateJwt(user);
            return token;
        }


        public async Task<ProfileDto> GetProfile(ClaimsPrincipal userPrincipal)
        {
            var username = userPrincipal.FindFirstValue("username");

            if (username == null)
            {
                throw new BadRequestException("Token is invalid");
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new NotFoundException("User with provided username does not exist");
            }

            return _mapper.Map<ProfileDto>(user);
        }


        private string GenerateJwt(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Id),
              new Claim("username", user.UserName),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Audience"],
              claims: claims,
              expires: DateTime.UtcNow.AddDays(1),
              signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
