using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        static int id = 0;
        static List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
            id++;
        }

        public void DeleteUser(int id)
        {
            User user = users.Find(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public User GetUserById(int id)
        {
            User user = users.Find(u => u.Id == id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }
    }
}
