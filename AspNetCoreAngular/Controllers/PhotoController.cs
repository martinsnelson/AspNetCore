using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAngular.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase 
    {
        public object get()
        {
            return new { versao = "PHOTO-1"};
        }
    }
}