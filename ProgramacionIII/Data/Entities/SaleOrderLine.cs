using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProgramacionIII.Data.Entities
{
    public class SaleOrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleOrderLineId { get; set; }
        public int ProductQuantity { get; set; } //cantidad

        [ForeignKey("ProductId")]
        public  Product? Product {  get; set; } 
        public int ProductId { get; set; }

        [ForeignKey("SaleOrderId")]
        public SaleOrder? SaleOrder { get; set; }
        public int SaleOrderId { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
