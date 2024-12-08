using System;
using System.Collections.Generic;

namespace JobCandidateHubAPI.Entity;

public partial class TblCandidate
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string? CallTimeInterval { get; set; }

    public string? LinkedInUrl { get; set; }

    public string? GithubUrl { get; set; }

    public string Comment { get; set; } = null!;
}
