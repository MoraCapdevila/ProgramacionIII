using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;

namespace ProgramacionIII.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserByUsername(string username);

        public int CreateUser(User user);
        public void UpdateUser(string username, CustomerPutDto updateUser);

        public void DeleteUser(string username);
    }
}
