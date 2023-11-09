using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramacionIII.Data.Entities
{
    public class SaleOrder
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; } //clave foranea

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; } //clave foranea

        public double SalePrice { get; set; } //debe coincidir con la porp de product, hacer validacion

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; } //clave foranea
    }
}
