using BookstoreApplication.Dtos;
using System.Security.Claims;

namespace BookstoreApplication.Service.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto data);
        Task<string> LoginAsync(LoginDto data);
        Task<ProfileDto> GetProfile(ClaimsPrincipal userPrincipal);


    }
}
