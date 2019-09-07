namespace AspNetCore.Entities 
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Senha { get; set; }
        public byte[] Salt { get; set; }
    }
}