using TodoAspNetAPI.Dto.StepDtos;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Mappers
{
    public static class StepMapper
    {
        public static StepDto ToStepDto(this Step StepModel)
        {
            return new StepDto
            {
                Id = StepModel.Id,
                Description = StepModel.Description,
                CreatedOn = StepModel.CreatedOn,
                UpdatedOn = StepModel.UpdatedOn,
            };
        }
    }
}