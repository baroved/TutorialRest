using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersService m_UserService;
        public UsersController(IUsersService userService)
        {
            m_UserService = userService;
        }
        
        [Route("api/users")]
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await m_UserService.GetUsersAsync();
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public async Task<User> GetUserById(int id)
        {
            return await m_UserService.GetUserAsync(id);
        }

        [Route("api/users")]
        [HttpPost]
        public async Task<bool> AddUser(User newUser)
        {
            return await m_UserService.AddUserAsync(newUser);
        }

        [Route("api/users/{id}")]
        [HttpPut]
        public async Task<bool> UpdateUser(int id, User currentUser)
        {
            return await m_UserService.UpdateUserAsync(id, currentUser);
        }

        [Route("api/users/{id}")]
        [HttpDelete]
        public async Task<bool> DeleteUser(int id)
        {
            return await m_UserService.DeleteUserAsync(id);
        }
    }
}
