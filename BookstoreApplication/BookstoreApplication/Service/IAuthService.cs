using BookstoreApplication.Dtos;

namespace BookstoreApplication.Service
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto data);
        Task LoginAsync(LoginDto data);
    }
}
