using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionIII.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }

        //public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        //public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
    }
}
