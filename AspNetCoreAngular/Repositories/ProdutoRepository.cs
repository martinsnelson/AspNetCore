using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular.Data;
using AspNetCoreAngular.DTO;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngular.Repositories
{
    public class ProdutoRepository
    {
        private readonly AspNetCoreAngularContext _context;

        public ProdutoRepository(AspNetCoreAngularContext context)
        {
            _context = context;
        }

        public IEnumerable<ProdutoDTO> ObterProdutos()
        {
            return _context
            .Produtos
            .Include(x => x.Categoria)
            .Select(x => new ProdutoDTO
            {
                ProdutoID = x.ProdutoID,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Preco = x.Preco,
                Categoria = x.Categoria.Nome,
                CategoriaID = x.CdCategoria
            })
            .AsNoTracking()
            .ToList();
        }
        
    }
}