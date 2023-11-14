using Microsoft.AspNetCore.Mvc;
using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly EcommerceContext _context;

        public CustomerService(EcommerceContext context)
        {
            _context = context;
        }

        public List<User> GetAllCustomers()
        {
            return _context.Users.Where(c => c.UserType == "Customer").ToList();
        }

        


    }   
}
