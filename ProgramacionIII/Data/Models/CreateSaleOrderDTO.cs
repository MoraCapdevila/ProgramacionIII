namespace ProgramacionIII.Data.Models
{
    public class CreateSaleOrderDTO
    {
        public int CustomerId { get; set; }
        public List<ProductQuantityDTO> Products { get; set; }
    }
}
