namespace APICompraV1.DTOs
{
    public class CompraDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
