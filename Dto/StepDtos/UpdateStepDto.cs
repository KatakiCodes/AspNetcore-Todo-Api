using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Dto.StepDtos
{
    public class UpdateStepDto
    {
        [Required(ErrorMessage = "A descrição do passo deve ser informada")]
        [MaxLength(1024, ErrorMessage = "A descrição do passo deve contér no máximo 1024 caractéres")]
        public string Description { get; set; } = string.Empty;
    }
}