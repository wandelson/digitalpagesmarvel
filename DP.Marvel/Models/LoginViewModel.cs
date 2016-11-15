using System.ComponentModel.DataAnnotations;

namespace DP.Marvel.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string PublicKey { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string PrivateKey { get; set; }
    }
}