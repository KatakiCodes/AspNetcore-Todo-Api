using Microsoft.EntityFrameworkCore;
using TodoAspNetAPI.Data;
using TodoAspNetAPI.Interfaces;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Repositories
{
    public class TargetRepository : ITargetInteface
    {
        private readonly AppDbContext _appDbContext;

        public TargetRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Target> CreateTarget(Target model)
        {
            await this._appDbContext.Targets.AddAsync(model);
            await this._appDbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteTarget(Target model)
        {
            this._appDbContext.Targets.Remove(model);
            await this._appDbContext.SaveChangesAsync();
        }

        public async Task<Target> GetTargetById(int Id)
        {
            Target? target = await this._appDbContext.Targets.Include(x => x.Steps).Where(x => x.Id == Id).FirstOrDefaultAsync();
            return target;
        }

        public async Task<IEnumerable<Target>> GetTargets()
        {
            var targets = await this._appDbContext.Targets.Include(x => x.Steps).ToListAsync();
            return targets;
        }

        public async Task<Target> UpdateTarget(Target model)
        {
            this._appDbContext.Entry<Target>(model).State = EntityState.Modified;
            await this._appDbContext.SaveChangesAsync();
            return model;
        }
    }
}