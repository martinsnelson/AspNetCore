using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Data;
using AspNetCore.DTO;
using AspNetCore.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AspNetCoreContext _context;

        public ProdutoRepository(AspNetCoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProdutos()
        {
            return await _context
            .Produtos
            .Include(x => x.Categoria)
            .Include(x => x.Fornecedor)
            .Select(x => new ProdutoDTO
            {
                ProdutoID = x.ProdutoID,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Preco = x.Preco,

                Categoria = x.Categoria.Nome,
                CategoriaID = x.CdCategoria,

                Fornecedor = x.Fornecedor.Nome,
                FornecedorID = x.CdFornecedor
            })
            .AsNoTracking()
            .ToListAsync();
        }
        
    }
}