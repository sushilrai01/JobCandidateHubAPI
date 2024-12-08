using JobCandidateHubAPI.Controllers;
using JobCandidateHubAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.CommonHelper
{
    public class DbOptions : IDbOptions
    {
        public DbContextOptions<JobCandidateHubDbContext> ConOptions { get; set; }
        public DbOptions(DbContextOptions<JobCandidateHubDbContext> uoptions)
        {
            ConOptions = uoptions;
        }
    }
    public interface IDbOptions
    {
        DbContextOptions<JobCandidateHubDbContext> ConOptions { get; set; }

    }
}

