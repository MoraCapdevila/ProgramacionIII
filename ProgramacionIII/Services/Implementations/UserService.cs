using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly EcommerceContext _context;

        public UserService(EcommerceContext context)
        {
            _context = context;
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(c => c.UserName == username);
        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public string UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            existingUser.Name=user.Name;
            existingUser.Email=user.Email;
            existingUser.LastName = user.LastName;
            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;

            _context.Update(existingUser);
            _context.SaveChanges();
            return existingUser.UserName;   
        }

        public void DeleteUser(string username)
        {
            User existingUser = _context.Users.FirstOrDefault(c => c.UserName == username);
            if (existingUser != null)
            {
                _context.Remove(existingUser);
                _context.SaveChanges();
            }

        }

        public List<User> GetAllCustomers()
        {
            return _context.Users.Where(c => c.UserType == "Customer").ToList();
        }

        public List<User> GetAllAdmins()
        {
            return _context.Users.Where(c => c.UserType == "Admin").ToList();
        }

    }
}
