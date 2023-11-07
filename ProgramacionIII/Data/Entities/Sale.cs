namespace ProgramacionIII.Data.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        public int UseriId { get; set; } //clave foranea

        public int ProductId { get; set; } //clave foranea

        public double SalePrice { get; set; } //debe coincidir con la porp de product, hacer validacion?oduct>();
    }
}
