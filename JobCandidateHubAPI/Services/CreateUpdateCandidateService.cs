using JobCandidateHubAPI.Entity;
using JobCandidateHubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Services
{
    public class CreateUpdateCandidateService(IDbContextFactory<JobCandidateHubDbContext> contextFactory) : ICreateUpdateCandidate
    {
        public async Task<Guid> CreateUpdateCandidateInfo(CandidateInfoModel model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var candidate = new TblCandidate()
            {
              
            };
            var test = context.TblCandidates.ToList();

            return Guid.NewGuid();
        }
    }
}
