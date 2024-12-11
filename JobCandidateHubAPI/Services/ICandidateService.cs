using JobCandidateHubAPI.Models;

namespace JobCandidateHubAPI.Services
{
    public interface ICandidateService
    {
        Task<Guid> CreateUpdateCandidateInfo(CandidateInfoModel model);
    }
}
