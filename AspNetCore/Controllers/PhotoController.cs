using System.Threading.Tasks;
using AspNetCore.Interface.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase 
    {
        private readonly IPhotoRepository _repo;
        private readonly IMapper _mapper;
        public PhotoController(IPhotoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getPhotos()
        {
            var dados = await _repo.getPhotos();
            return Ok(dados);
        }
        
        public object get()
        {
            return new { versao = "PHOTO-1"};
        }
    }
}