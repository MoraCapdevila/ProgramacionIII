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
        public double TotalPrice { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public  Product? Product {  get; set; } 
        

        [ForeignKey("SaleOrderId")]
        public SaleOrder? SaleOrder { get; set; }
        public int SaleOrderId { get; set; }
        
        
    }
}
