using be_project.Models;

namespace be_project.Services
{
    public interface IAuthService
    {
        Task<TokenResult> GetTokenFromGoogle(string code);
        Task<User> GetUserFromGoogleAsync(string idToken);
        Task<string> LoginWithGoogleAsync();
        Task<User> AddUserAsync(UserDto user);
    }
}
