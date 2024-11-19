using TodoAspNetAPI.Dto.StepDtos;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Interfaces
{
    public interface IStepInterface
    {
        public Task<IEnumerable<Step>> GetSteps();
        public Task<Step> GetStepById(int Id);
        public Task<Step> CreateStep(Step model);
        public Task<Step> UpdateStep(Step model);
        public Task DeleteStep(Step model);
    }
}