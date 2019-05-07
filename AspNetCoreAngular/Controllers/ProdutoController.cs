using System.Threading.Tasks;
using AspNetCoreAngular.Data;
using AspNetCoreAngular.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngular.Controllers
{
    [Authorize]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _repo;
        private readonly IMapper _mapper;
        private readonly AspNetCoreAngularContext _context;
        public ProdutoController(ProdutoRepository repo, AspNetCoreAngularContext context)
        {
            _repo = repo;
            _context = context;
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpGet]
        public async Task<IActionResult> ObterProdutos()
        {
            var dados = await _context.Produtos.ToListAsync();
            return Ok(dados);
        }

        //[EnableCors]
        //[HttpGet]
        // public IActionResult ObterProdutos()
        // {
        //     var dados = _repo.ObterProdutos();
        //     return Ok(dados);
        // }
    }
}