namespace ProgramacionIII.Data.Entities
{
    public class Customer : User
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
