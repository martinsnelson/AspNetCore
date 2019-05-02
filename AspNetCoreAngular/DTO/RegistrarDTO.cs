using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetCoreAngular.DTO
{
    [DataContract]
    public class RegistrarDTO 
    {
        [DataMember]
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O Nome deve ter no minimo 3 caracteres")]
        public string Nome { get; set; }

        [DataMember]
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O E-mail deve ter no minimo 3 caracteres")]        
        public string Email { get; set; }

        [DataMember]
        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Sua senha deve ter entre 8 e 20 caracteres")]        
        public string Senha { get; set; }        
    }
}