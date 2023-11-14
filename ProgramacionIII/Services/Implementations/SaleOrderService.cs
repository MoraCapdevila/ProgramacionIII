using ProgramacionIII.Data.Context;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Services.Implementations
{
    public class SaleOrderService : ISaleOrderLineService
    {
        private readonly EcommerceContext _context;

        public SaleOrderService(EcommerceContext context)
        {
            _context = context;
        }
    }
}
