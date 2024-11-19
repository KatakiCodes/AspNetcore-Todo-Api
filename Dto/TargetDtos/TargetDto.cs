using TodoAspNetAPI.Dto.StepDtos;
using TodoAspNetAPI.Dto.UserDtos;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Dto.TargetDtos
{
    public class TargetDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IEnumerable<StepDto>? Steps { get; set; }
    }
}