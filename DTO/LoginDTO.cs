using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetCore.DTO
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