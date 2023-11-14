using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
using ProgramacionIII.Data.Models;
using ProgramacionIII.Services.Interfaces;

namespace ProgramacionIII.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly EcommerceContext _context;

        public ProductService(EcommerceContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById (int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public int CreateProduct(Product product) 
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void UpdateProduct(Product product) 
        { 
           _context.Update(product);
           _context.SaveChanges();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
           
        }
    }
}
