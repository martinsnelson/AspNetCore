using System.Threading.Tasks;
using AspNetCoreAngular.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngular.Controllers
{
    [Authorize]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AspNetCoreAngularContext _context;

        public ProdutoController(AspNetCoreAngularContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutos()
        {
            var dados = await _context.Produtos.ToListAsync();
            return Ok(dados);
        }
    }
}