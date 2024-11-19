using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Interfaces
{
    public interface ITargetInteface
    {
        public Task<IEnumerable<Target>> GetTargets();
        public Task<Target> GetTargetById(int Id);
        public Task<Target> CreateTarget(Target model);
        public Task<Target> UpdateTarget(Target model);
        public Task DeleteTarget(Target model);
    }
}