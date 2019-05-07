using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreAngular.DTO;
using AspNetCoreAngular.Entities;
using AspNetCoreAngular.Interface.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreAngular.Controllers 
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistrarDTO registrarDTO)
        {
            registrarDTO.Email = registrarDTO.Email.ToLower();
            if(await _repo.UsuarioExiste(registrarDTO.Email))
                return BadRequest("Email já existe");

            var criarUsuario = _mapper.Map<Usuario>(registrarDTO);
            var usuarioCriado = await _repo.Registrar(criarUsuario, registrarDTO.Senha);

            return StatusCode(201, new { email = usuarioCriado.Email, nome = usuarioCriado.Nome });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var usuarioRepo = await _repo.Login(loginDTO.Email.ToLower(), loginDTO.Senha);
            if(usuarioRepo == null)
                return Unauthorized();
            
            var claims = new []
            {
               new Claim(ClaimTypes.NameIdentifier, usuarioRepo.UsuarioID.ToString()),
               new Claim(ClaimTypes.Name, usuarioRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {token = tokenHandler.WriteToken(token), email = usuarioRepo.Email, nome = usuarioRepo.Nome});
        }
    }
}