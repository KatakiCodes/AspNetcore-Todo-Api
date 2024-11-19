using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "A descrição do passo deve ser informada")]
        [MaxLength(1024, ErrorMessage = "A descrição do passo deve contér no máximo 1024 caractéres")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Target Target { get; set; }
    }
}