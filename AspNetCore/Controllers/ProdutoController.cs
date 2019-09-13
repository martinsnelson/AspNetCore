using System.Threading.Tasks;
using AspNetCore.Data;
using AspNetCore.Interface.Repositories;
using AspNetCore.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    [Authorize]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //private readonly AspNetCoreContext _context;
        private readonly IProdutoRepository _repo;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // [EnableCors("AllowSpecificOrigin")]
        // [HttpGet]
        // public async Task<IActionResult> ObterProdutos()
        // {
        //     var dados = await _context.Produtos.ToListAsync();
        //     return Ok(dados);
        // }

        //[EnableCors]
        [HttpGet]
        public async Task<IActionResult> ObterProdutos()
        {
            var dados = await _repo.ObterProdutos();
            return Ok(dados);
        }
    }
}