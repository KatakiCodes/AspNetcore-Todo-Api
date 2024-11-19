using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoAspNetAPI.Models
{
    public class Target
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o título da tarefa")]
        [MaxLength(120, ErrorMessage = "O título da tarefa deve contér no máximo 120 caractéres")]
        public string Title { get; set; } = string.Empty;
        [MaxLength(1024, ErrorMessage = "A descroção da tarefa deve contér no máximo 1024 caractéres")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required]
        public User User { get; set; }
        public IEnumerable<Step> Steps { get; set; }

        public Target()
        {
            this.Steps = new List<Step>();
        }
    }
}