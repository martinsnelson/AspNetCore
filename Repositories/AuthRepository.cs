using System.Threading.Tasks;
using AspNetCore.Data;
using AspNetCore.Entities;
using AspNetCore.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AspNetCoreContext _context;

        public AuthRepository(AspNetCoreContext context)
        {
            _context = context;
        }

        # region Metodos Publicos

        public async Task<Usuario> Login(string email, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            if(usuario == null)
                return null;

            if(!VerificarHashSenha(senha, usuario.Senha, usuario.Salt))
                return null;

            return usuario; // autenticação com sucesso
        }

        public async Task<Usuario> Registrar(Usuario usuario, string senha)
        {
            byte[] senhaHash, salt;
            CriarSenhaHash(senha, out senhaHash, out salt);
            usuario.Senha = senhaHash;
            usuario.Salt = salt;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> UsuarioExiste(string usuarioNome)
        {
            if(await _context.Usuarios.AnyAsync(x => x.Email == usuarioNome))
                return true;

            return false;
        }

        #endregion

        private bool VerificarHashSenha(string senha, byte[] senhaHash, byte[] salt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var hashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                for(int i=0; i < hashCalculado.Length; i++)
                {
                    if(hashCalculado[i] != senhaHash[i])
                        return false;
                }
            }

            return true;
        }

        private void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }
    }
}