using TodoAspNetAPI.Dto.TargetDtos;
namespace TodoAspNetAPI.Dto.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public IEnumerable<TargetDto>? targets { get; set; }

    }
}