using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Interfaces;
using System;
//using System.Data.Entity;
//using System.Data.Entity;

namespace ProgramacionIII.Services.Implementations
{
    public class SaleOrderLineService : ISaleOrderLineService
    {
        private readonly EcommerceContext _context;

        public SaleOrderLineService(EcommerceContext context) 
        {
            _context = context;
        }

        public SaleOrderLine GetSaleOrderLine(int saleOrderLineId)
        {
            return _context.SaleOrderLines
                .Include(sol => sol.SaleOrder)
                .Include(sol => sol.Product)
                .FirstOrDefault(sol => sol.SaleOrderLineId == saleOrderLineId);
        }

        public List<SaleOrderLine> GetAllSaleOrderLines()
        {
            try
            {
                return _context.SaleOrderLines.ToList();
            }
            catch (Exception ex)
            {
               
                return new List<SaleOrderLine>(); 
            }
        }


        public bool DeleteSaleOrderLineById(int saleOrderLineId)
        {
            try
            {
                var saleOrderLine = _context.SaleOrderLines.Find(saleOrderLineId);

                if (saleOrderLine == null)
                {
                    return false; 
                }

                _context.SaleOrderLines.Remove(saleOrderLine);
                _context.SaveChanges();

                return true; 
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public int CreateSaleOrderLine(SaleOrderLineDTO dto)
        {
            try
            {
                var order = _context.SaleOrders.Find(dto.SaleOrderId);
                var product = _context.Products.Find(dto.ProductId);

                if (order == null || product == null)
                {
                    return -1; // si no encuentro so o product
                }

                var totalPrice = product.Price * dto.ProductQuantity;

                var saleOrderLine = new SaleOrderLine
                {
                    SaleOrderId = dto.SaleOrderId,
                    ProductId = dto.ProductId,
                    ProductQuantity = dto.ProductQuantity,
                    TotalPrice = totalPrice
                };

                _context.SaleOrderLines.Add(saleOrderLine);
                _context.SaveChanges();

                return saleOrderLine.SaleOrderLineId; // Devuevlco el id de la sol creada
            }
            catch (Exception ex)
            {
                
                return -1;
            }
        }

    }




}

