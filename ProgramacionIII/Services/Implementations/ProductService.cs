using ProgramacionIII.Data.Context;
using ProgramacionIII.Data.Entities;
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

        public Product GetProductById (int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product CreateProduct (Product product) 
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void UpdateProduct(Product product) 
        { 
           _context.Update(product);
           _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product productToDelete = _context.Products.FirstOrDefault(u => u.Id == id);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }
    }
}
