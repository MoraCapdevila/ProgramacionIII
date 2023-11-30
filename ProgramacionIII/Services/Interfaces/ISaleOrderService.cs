using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;

namespace ProgramacionIII.Services.Interfaces
{
    public interface ISaleOrderService
    {
        Task<IEnumerable<SaleOrder>> GetAllSaleOrdersAsync();
        SaleOrder GetSaleOrderById(int id);
        IEnumerable<SaleOrder> GetSaleOrdersByCustomerId(int customerId);

        public SaleOrder AddSaleOrder(SaleOrder saleOrder);
        SaleOrder UpdateSaleOrder(SaleOrder saleOrderToUpdate);
        bool DeleteSaleOrder(int id);
    }
}
