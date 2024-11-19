using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Dto.UserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Informe o seu Email")]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "A palavra passe do utilizador deve ser informada")]
        public string Password { get; set; } = string.Empty;
    }
}