using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.DTO;

namespace AspNetCore.Interface.Repositories
{
    public interface IProdutoRepository
    {
        Task <IEnumerable<ProdutoDTO>> ObterProdutos();   
    }
}