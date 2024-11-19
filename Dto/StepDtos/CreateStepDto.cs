using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Dto.StepDtos
{
    public class CreateStepDto
    {
        [Required(ErrorMessage = "A descrição do passo deve ser informada")]
        [MaxLength(1024, ErrorMessage = "A descrição do passo deve contér no máximo 1024 caractéres")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Id da tarefa deve ser referenciado")]
        public int IdTarget { get; set; }
    }
}