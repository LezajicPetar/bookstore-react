using BookstoreApplication.Dtos;
using System.Security.Claims;

namespace BookstoreApplication.Service
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto data);
        Task<string> LoginAsync(LoginDto data);
        Task<ProfileDto> GetProfile(ClaimsPrincipal userPrincipal);


    }
}
