using TodoAspNetAPI.Dto.TargetDtos;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Mappers
{
    public static class TargetMapper
    {
        public static TargetDto ToTargetDto(this Target TargetModel)
        {
            return new TargetDto
            {
                Id = TargetModel.Id,
                Title = TargetModel.Title,
                Description = TargetModel.Description,
                CreatedOn = TargetModel.CreatedOn,
                UpdatedOn = TargetModel.UpdatedOn,
                Steps = TargetModel.Steps.Select(a => a.ToStepDto())
            };
        }
    }
}