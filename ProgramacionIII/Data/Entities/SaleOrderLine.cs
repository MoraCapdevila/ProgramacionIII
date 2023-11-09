using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProgramacionIII.Data.Entities
{
    public class SaleOrderLine
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public  Product Product {  get; set; } 
        public int ProductId { get; set; }

        [ForeignKey("SaleOrder")]
        public SaleOrder SaleOrder { get; set; } 
        public int SaleOrderId { get; set; }
        public int ProductQuantity { get; set; } //cantidad
    }
}
