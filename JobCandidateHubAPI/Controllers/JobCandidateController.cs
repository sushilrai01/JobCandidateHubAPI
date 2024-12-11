using JobCandidateHubAPI.Models;
using JobCandidateHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobCandidateController(ICandidateService _candidateService) : ControllerBase
    {

        [HttpPost("CreateUpdateCandidate")] // ?name=test&
        public async Task<IActionResult> CreateUpdateCandidate([FromBody] CandidateInfoModel model)
        {
            var response = await _candidateService.CreateUpdateCandidateInfo(model);
            return Ok(response);
        }

      
    }
}
