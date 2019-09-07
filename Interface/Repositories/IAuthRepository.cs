using System.Threading.Tasks;
using AspNetCore.Entities;

namespace AspNetCore.Interface.Repositories
{
    public interface IAuthRepository
    {
        Task<Usuario> Registrar(Usuario usuario, string senha);
        Task<Usuario> Login(string usuarioNome, string senha);
        Task<bool> UsuarioExiste(string usuarioNome);
    }
}