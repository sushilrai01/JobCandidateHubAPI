using JobCandidateHubAPI.Models;

namespace JobCandidateHubAPI.Services
{
    public interface ICreateUpdateCandidate
    {
        Task<Guid> CreateUpdateCandidateInfo(CandidateInfoModel model);
    }
}
