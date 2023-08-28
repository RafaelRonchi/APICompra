using APICompraV1.Models;

namespace APICompraV1.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task CreateProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(int id, Produto produto);
        Task DeleteProdutoAsync(int id);
    }
}
