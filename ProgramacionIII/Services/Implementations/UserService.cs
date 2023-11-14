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
          

            
            
            
            //User existingCustomer = _context.Users.FirstOrDefault(u => u.UserName == username);

            //if (existingCustomer != null)
            //{

            //    existingCustomer.LastName = updateUser.LastName ?? existingCustomer.LastName;
            //    existingCustomer.Name = updateUser.Name ?? existingCustomer.Name;
            //    existingCustomer.Password = updateUser.Password ?? existingCustomer.Password;
            //    existingCustomer.UserName = updateUser.UserName ?? existingCustomer.UserName;
            //    existingCustomer.UserType = "Customer";
            //}
            //_context.SaveChanges();
         
        }

        public void DeleteUser(string userName)
        {
            User existingCustomer = _context.Users.FirstOrDefault(c => c.UserName == userName);
            if (existingCustomer != null)
            {
                _context.Remove(existingCustomer);
                _context.SaveChanges();
            }
            
        }

    }
}
