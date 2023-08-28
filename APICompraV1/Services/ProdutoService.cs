using APICompraV1.Models;

namespace APICompraV1.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly DataContext _dbContext;

        public ProdutoService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _dbContext.Produtos.FindAsync(id);
        }

        public async Task CreateProdutoAsync(Produto produto)
        {
            _dbContext.Produtos.Add(produto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto == null) return;

            _dbContext.Produtos.Remove(produto); 
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(int id, Produto produto)
        {
            if(id != produto.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            _dbContext.Entry(produto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
