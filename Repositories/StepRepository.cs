using Microsoft.EntityFrameworkCore;
using TodoAspNetAPI.Data;
using TodoAspNetAPI.Interfaces;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Repositories
{
    public class StepRepository : IStepInterface
    {
        private readonly AppDbContext _appDbContext;
        public StepRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Step> CreateStep(Step model)
        {
            await this._appDbContext.Steps.AddAsync(model);
            await this._appDbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteStep(Step model)
        {
            this._appDbContext.Steps.Remove(model);
            await this._appDbContext.SaveChangesAsync();
        }

        public async Task<Step> GetStepById(int Id)
        {
            Step? step = await this._appDbContext.Steps.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return step;
        }

        public async Task<IEnumerable<Step>> GetSteps()
        {
            var steps = await this._appDbContext.Steps.ToListAsync();
            return steps;
        }

        public async Task<Step> UpdateStep(Step model)
        {
            this._appDbContext.Entry<Step>(model).State = EntityState.Modified;
            await this._appDbContext.SaveChangesAsync();
            return model;
        }
    }
}