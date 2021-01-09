using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<bool> AddUserAsync(User user);

        Task<bool> DeleteUserAsync(int id);

        Task<bool> UpdateUserAsync(int id, User user);
    }
}
