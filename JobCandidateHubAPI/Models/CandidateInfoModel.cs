using System.ComponentModel.DataAnnotations;

namespace JobCandidateHubAPI.Models
{
    public class CandidateInfoModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? PhoneNo { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; }
        public string? CallTimeInterval { get; set; }

        public string? LinkedInUrl { get; set; }

        public string? GithubUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
