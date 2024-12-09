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

            var candidates = await context.TblCandidates.Where(x =>
                x.EmailAddress.Trim().ToLower() == model.EmailAddress.Trim().ToLower()).FirstOrDefaultAsync();

            if (candidates != null)
            {
                candidates.FirstName = model.FirstName;
                candidates.LastName = model.LastName;
                candidates.EmailAddress = model.EmailAddress;
                candidates.Comment = model.Comment;
                candidates.CallTimeInterval = model.CallTimeInterval;
                candidates.GithubUrl = model.GithubUrl;
                candidates.LinkedInUrl = model.LinkedInUrl;
                candidates.PhoneNo = model.PhoneNo;

                await context.SaveChangesAsync();
                return candidates.Id;
            }

            var candidate = new TblCandidate()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                CallTimeInterval = model.CallTimeInterval,
                Comment = model.Comment,
                GithubUrl = model.GithubUrl,
                LinkedInUrl = model.LinkedInUrl,
                PhoneNo = model.PhoneNo,
            };

            context.TblCandidates.Add(candidate);
            await context.SaveChangesAsync();
            return candidate.Id;


        }
    }
}
