using System.ComponentModel.DataAnnotations;

namespace TodoAspNetAPI.Dto.TargetDtos
{
    public class CreateTargetDto
    {
        [Required(ErrorMessage = "Informe o título da tarefa")]
        [MaxLength(120, ErrorMessage = "O título da tarefa deve contér no máximo 120 caractéres")]
        public string Title { get; set; } = string.Empty;
        [MaxLength(1024, ErrorMessage = "A descrição da tarefa deve contér no máximo 1024 caractéres")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "O id do utilizador deve ser referenciado")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do utilizador deve ser maior que zero")]
        public int IdUser { get; set; }
    }
}