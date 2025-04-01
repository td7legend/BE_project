using be_project.Models;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public interface IUserRepository
    {
        Task UpdateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string email);
        Task AddUserAsync(User user);
        Task<User> GetUserByGoogleIdAsync(string googleId);
        Task<bool> EmailExistsAsync(string email);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
    }
}
