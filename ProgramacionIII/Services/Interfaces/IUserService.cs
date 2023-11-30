using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;

namespace ProgramacionIII.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserByUsername(string username);

        public int CreateUser(User user);
        public string UpdateUser(User user);

        public void DeleteUser(string username);

        public List<User> GetAllCustomers();
        public List<User> GetAllAdmins();
    }
}
