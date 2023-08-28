namespace APICompraV1.Services.Interfaces
{
    public interface ICompraService
    {
        Task<IEnumerable<Compra>> GetComprasAsync();
        Task<Compra> GetCompraByIdAsync(int id);
        Task CreateCompraAsync(Compra compra);
    }
}
