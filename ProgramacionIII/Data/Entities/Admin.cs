namespace ProgramacionIII.Data.Entities
{
    public class Admin : User
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<SaleOrder> Sale { get; set; } = new List<SaleOrder>();
    }
}
