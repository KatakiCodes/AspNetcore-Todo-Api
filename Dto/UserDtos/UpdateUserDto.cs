using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Dto.UserDtos
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "Informe o seu Email")]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O nome do utilizador deve ser informado")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "A palavra passe do utilizador deve ser informada")]
        public string Password { get; set; } = string.Empty;

    }
}