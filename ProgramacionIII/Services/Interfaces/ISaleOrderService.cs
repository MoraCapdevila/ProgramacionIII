using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;

namespace ProgramacionIII.Services.Interfaces
{
    public interface ISaleOrderService
    {
        //List<SaleOrder> GetAllOrders();
        //public SaleOrder GetSaleOrderByCustomer(int customerId);
        public SaleOrder? GetOne(int id);
        public List<SaleOrder> GetSaleOrderByCustomer(int cutomerId);
        //public void AddSaleOrder(SaleOrderDto dto);
        Task<SaleOrder> CreateSaleOrderAsync(CreateSaleOrderDTO createSaleOrderDTO);
        public SaleOrder AddSaleOrder(SaleOrder saleOrder);
        public bool UpdateSaleOrder(int id, SaleOrderDto dto);
        public bool DeleteSaleOrder(int id);
    }
}
