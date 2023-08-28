namespace APICompraV1.Models
{
    public class Compra
    {
       
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public int ProdutoId { get; set; }
            public DateTime DataCompra { get; set; }

            public Cliente Cliente { get; set; }
            public Produto Produto { get; set; }
        
    }
}
