
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

        public SaleOrder? GetOne(int id)
        {
            return _context.SaleOrders
                            .Include(so => so.Customer)
                            .Include(sol => sol.SaleOrderLines)
                            .ThenInclude(p => p.Product)
                            .SingleOrDefault(x =>x.Id ==id);
        }

        public List<SaleOrder> GetSaleOrderByCustomer(int customerId)
        {
            return _context.SaleOrders
                            .Include(so => so.Customer)
                            .Include(sol => sol.SaleOrderLines)
                            .ThenInclude(p => p.Product)
                            .Where(o => o.CustomerId == customerId)
                            .ToList();
        }

        //public void AddSaleOrder(SaleOrderDto dto)
        //{

        //    SaleOrder newSaleOrder = new SaleOrder
        //    {
        //        CustomerId = dto.CustomerId,
        //        TotalPrice = dto.TotalPrice,
        //    }; 
        //    _context.SaleOrders.Add(newSaleOrder);
        //    _context.SaveChanges();
        //}

        public async Task<SaleOrder> CreateSaleOrderAsync(CreateSaleOrderDTO createSaleOrderDTO)
        {
            var saleOrder = new SaleOrder
            {
                CustomerId = createSaleOrderDTO.CustomerId,
                SaleOrderLines = new List<SaleOrderLine>()
            };

            foreach (var productQuantityDTO in createSaleOrderDTO.Products)
            {
                var product = await _context.Products.FindAsync(productQuantityDTO.ProductId);
                if (product == null)
                {
                    // Manejo de error: producto no encontrado
                    // Puedes lanzar una excepción o manejarlo según tu lógica de negocio
                    throw new ArgumentException($"Product with ID {productQuantityDTO.ProductId} not found.");
                }

                var saleOrderLine = new SaleOrderLine
                {
                    ProductId = product.Id,
                    ProductQuantity = productQuantityDTO.Quantity,
                    TotalPrice = product.Price * productQuantityDTO.Quantity
                    // Puedes calcular el precio total por línea según tus necesidades
                };

                saleOrder.SaleOrderLines.Add(saleOrderLine);
            }

            _context.SaleOrders.Add(saleOrder);
            await _context.SaveChangesAsync();

            return saleOrder;
        }

        public SaleOrder AddSaleOrder(SaleOrder saleOrder)
        {
            _context.Add(saleOrder);
            _context.SaveChanges();
            return saleOrder;
        }

        public bool UpdateSaleOrder(int id, SaleOrderDto dto)
        {
            var saleOrder = _context.SaleOrders.Find(id);

            if (saleOrder == null)
            {
                return false;
            }

            saleOrder.CustomerId = dto.CustomerId;
            //saleOrder.TotalPrice = dto.TotalPrice;

            _context.SaveChanges();

            return true;
        }

        public bool DeleteSaleOrder(int id)
        {
            var orderToDelete = _context.SaleOrders.Find(id);
            if (orderToDelete == null)
            {
                return false; // La orden de venta no se encontró
                
            }

            _context.SaleOrders.Remove(orderToDelete);
            _context.SaveChanges();
            return true; // La orden de venta fue eliminada exitosamente
        }
    }
}
