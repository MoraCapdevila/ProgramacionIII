using ProgramacionIII.Data.Entities;

namespace ProgramacionIII.Services.Interfaces
{
    public interface IProductService
    {
        public Product GetProductById(int id);
        public Product CreateProduct(Product product);
        public void UpdateProduct(Product product);

        public void DeleteProduct(int id);
    }
}
