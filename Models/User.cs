using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o seu Email")]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O nome do utilizador deve ser informado")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "A palavra passe do utilizador deve ser informada")]
        public string Password { get; set; } = string.Empty;
        public IEnumerable<Target> Targets { get; set; }

        public User()
        {
            this.Targets = new List<Target>();
        }
    }
}