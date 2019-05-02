using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAngular.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return new { versao = "Versão 0.0.1" };
        }   
    }
}