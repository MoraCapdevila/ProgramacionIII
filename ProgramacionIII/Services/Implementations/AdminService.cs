using ProgramacionIII.Data.Context;
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
    }
}
