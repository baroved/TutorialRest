using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UsersService : IUsersService
    {
        private readonly DBContext m_Session;

        public UsersService(DBContext session)
        {
            m_Session = session;
        }
        public Task<bool> AddUserAsync(User user)
        {
            try
            {
                m_Session.Users.Add(user);
                m_Session.SaveChangesAsync();
                return Task.FromResult(true);
            }

            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = m_Session.Users.Where(x => x.Id == id).FirstOrDefault<User>();

                if (user == null)
                    return Task.FromResult(false);
                m_Session.Users.Remove(user);
                m_Session.SaveChangesAsync();
                return Task.FromResult(true);
            }

            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<User> GetUserAsync(int id)
        {
            try
            {
                var user = m_Session.Users.Where(x => x.Id == id).FirstOrDefault<User>();

                if (user == null)
                    return null;
                return Task.FromResult(user);
            }

            catch (Exception)
            {
                return null;
            }
        }

        public Task<List<User>> GetUsersAsync()
        {
            try
            {
                var users = m_Session.Users.ToList<User>();
                return Task.FromResult(users);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> UpdateUserAsync(int id, User user)
        {
            try
            {
                var oldUser = m_Session.Users.Where(x => x.Id == id).FirstOrDefault<User>();

                if (user == null)
                    return Task.FromResult(false);
                oldUser.Name = user.Name;
                oldUser.Age = user.Age;
                m_Session.SaveChangesAsync();
                return Task.FromResult(true);
            }

            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}