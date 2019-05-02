using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetCoreAngular.DTO
{
    [DataContract]
    public class LoginDTO
    {
        [DataMember]
        [Required]
        public string Email { get; set; }
        
        [DataMember]
        [Required]
        public string Senha { get; set; }
    }
}