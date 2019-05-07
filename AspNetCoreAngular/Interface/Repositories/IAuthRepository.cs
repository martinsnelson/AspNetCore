using System.Threading.Tasks;
using AspNetCoreAngular.Entities;

namespace AspNetCoreAngular.Interface.Repositories
{
    public interface IAuthRepository
    {
        Task<Usuario> Registrar(Usuario usuario, string senha);
        Task<Usuario> Login(string usuarioNome, string senha);
        Task<bool> UsuarioExiste(string usuarioNome);
    }
}