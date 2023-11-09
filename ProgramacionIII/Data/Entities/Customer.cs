namespace ProgramacionIII.Data.Entities
{
    public class Customer : User
    {

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
