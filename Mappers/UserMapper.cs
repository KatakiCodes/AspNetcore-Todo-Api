using TodoAspNetAPI.Dto.TargetDtos;
using TodoAspNetAPI.Dto.UserDtos;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Email = userModel.Email,
                UserName = userModel.UserName,
                targets = userModel.Targets.Select(x => x.ToTargetDto())
            };
        }
    }
}