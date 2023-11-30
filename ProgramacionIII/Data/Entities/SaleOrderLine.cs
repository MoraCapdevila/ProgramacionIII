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
        public float TotalPrice { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public  Product? Product {  get; set; } 
        

        [ForeignKey("SaleOrderId")]
        public int SaleOrderId { get; set; }
        public SaleOrder? SaleOrder { get; set; }
        

        //public ICollection<Product> Products { get; set; } = new List<Product>();
        //public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    }
}
