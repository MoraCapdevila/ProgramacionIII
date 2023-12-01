
using Microsoft.EntityFrameworkCore;
using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Interfaces;
//using System.Data.Entity;


namespace ProgramacionIII.Services.Implementations
{
    public class SaleOrderService : ISaleOrderService
    {
        private readonly EcommerceContext _context;

        public SaleOrderService(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SaleOrder>> GetAllSaleOrdersAsync()
        {
            return await _context.SaleOrders.ToListAsync(); 
        }
        public SaleOrder GetSaleOrderById(int id)
        {
            return _context.SaleOrders
                .Include(so => so.Customer)
                .FirstOrDefault(so => so.Id == id);

        }

        public IEnumerable<SaleOrder> GetSaleOrdersByCustomerId(int customerId)
        {
            return _context.SaleOrders
                .Include(so =>so.Customer)
                .Where(so => so.CustomerId == customerId)
                .ToList();
        }



        public SaleOrder AddSaleOrder(SaleOrder saleOrder)
        {
            _context.Add(saleOrder);
            _context.SaveChanges();
            return saleOrder;
        }

        public SaleOrder UpdateSaleOrder(SaleOrder saleOrderToUpdate)
        {
            var existingSaleOrder = _context.SaleOrders.FirstOrDefault(so => so.Id == saleOrderToUpdate.Id);

            if (existingSaleOrder == null)
            {
                return null;
            }
  
            existingSaleOrder.CustomerId = saleOrderToUpdate.CustomerId;
            existingSaleOrder.ProductId = saleOrderToUpdate.ProductId;
            existingSaleOrder.ProductQuantity = saleOrderToUpdate.ProductQuantity;

            _context.SaveChanges(); 

            return existingSaleOrder;
        }

        public bool DeleteSaleOrder(int id)
        {
            var saleOrderToDelete = _context.SaleOrders.FirstOrDefault(so => so.Id == id);

            if (saleOrderToDelete == null)
            {
                return false;
            }

            _context.SaleOrders.Remove(saleOrderToDelete);
            _context.SaveChanges(); 

            return true;
        }
    }
}
