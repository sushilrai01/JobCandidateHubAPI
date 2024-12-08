using JobCandidateHubAPI.CommonHelper;
using JobCandidateHubAPI.Entity;
using JobCandidateHubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Services
{
    public class CreateUpdateCandidateService : ICreateUpdateCandidate
    {
        public IDbOptions _dbOptions;
        public CreateUpdateCandidateService(IDbOptions dboptions)
        {
            _dbOptions = dboptions;
        }
        public async Task<Guid> CreateUpdateCandidateInfo(CandidateInfoModel model)
        {
            await using var context = new JobCandidateHubDbContext(_dbOptions.ConOptions);

            var candidate = new TblCandidate()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress =model.EmailAddress,
                CallTimeInterval = model.CallTimeInterval,
                Comment =model.Comment,
                GithubUrl = model.GithubUrl,
                LinkedInUrl =model.LinkedInUrl,
                PhoneNo = model.PhoneNo,
            };

            context.TblCandidates.Add(candidate);
            await context.SaveChangesAsync();

            return candidate.Id;
        }
    }
}
