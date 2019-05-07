using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreAngular.DTO;

namespace AspNetCoreAngular.Interface.Repositories
{
    public interface IProdutoRepository
    {
        Task <IEnumerable<ProdutoDTO>> ObterProdutos();   
    }
}