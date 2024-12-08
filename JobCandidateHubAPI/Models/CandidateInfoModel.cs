namespace JobCandidateHubAPI.Models
{
    public class CandidateInfoModel
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; } = "test";

        public string LastName { get; set; } = "test";

        public string? PhoneNo { get; set; }

        public string EmailAddress { get; set; }

        public string? CallTimeInterval { get; set; }

        public string? LinkedInUrl { get; set; }

        public string? GithubUrl { get; set; }

        public string Comment { get; set; }
    }
}
