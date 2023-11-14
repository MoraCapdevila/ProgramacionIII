using ProgramacionIII.Data.Entities;

namespace ProgramacionIII.Services.Interfaces
{
    public interface IProductService
    {
        public Product GetProductById(int id);

        public List<Product> GetProducts();
        public int CreateProduct(Product product);
        public void UpdateProduct(Product product);

        public Task DeleteProduct(int id);
    }
}
