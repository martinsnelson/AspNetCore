using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace AspNetCoreAngular.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public object Get()
        {
            return new {
                versao = "Versão 0.0.1",
                key = _configuration["Key"],
                Password =_configuration["Password"],
                CultureInfo = CultureInfo.CurrentCulture.DisplayName };
        }   
    }
}