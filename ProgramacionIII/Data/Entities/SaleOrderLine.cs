using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramacionIII.Data.Entities
{
    public class SaleOrderLine
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("SaleOrder")]
        public int SaleOrderId { get; set; }
        public int ProductQuantity { get; set; } //cantidad
    }
}
