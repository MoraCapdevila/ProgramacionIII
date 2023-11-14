using ProgramacionIII.Data.Entities;

namespace ProgramacionIII.Services.Interfaces
{
    public interface IAdminService
    {
        public List<User> GetAllAdmins();
    }
}
