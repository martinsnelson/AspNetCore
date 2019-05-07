using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular.Data;
using AspNetCoreAngular.DTO;
using AspNetCoreAngular.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngular.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AspNetCoreAngularContext _context;

        public ProdutoRepository(AspNetCoreAngularContext context)
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