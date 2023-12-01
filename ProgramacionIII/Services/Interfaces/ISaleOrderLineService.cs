using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;

namespace ProgramacionIII.Services.Interfaces
{
    public interface ISaleOrderLineService
    {
        List<SaleOrderLine> GetAllSaleOrderLines();
        SaleOrderLine GetSaleOrderLine(int saleOrderLineId);
        bool DeleteSaleOrderLineById(int saleOrderLineId);
        public int CreateSaleOrderLine(SaleOrderLineDTO dto);
    }
}
