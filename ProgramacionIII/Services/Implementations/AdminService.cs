using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly EcommerceContext _context;

        public AdminService(EcommerceContext context)
        {
            _context = context;
        }

        public List<User> GetAllAdmins()
        {
            return _context.Users.Where(c => c.UserType == "Admin").ToList();
        }
    }
}
