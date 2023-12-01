using ProgramacionIII.Data.Entities;

namespace ProgramacionIII.Data.Models
{
    public class SaleOrderDto
    {
        public int CustomerId { get; set; }
        //public float TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

    }
}
