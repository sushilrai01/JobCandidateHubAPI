using JobCandidateHubAPI.CommonHelper;
using JobCandidateHubAPI.Entity;
using JobCandidateHubAPI.Models;
using JobCandidateHubAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JobCandidateHubApi.TESTS.UnitTesting;

public class CandidateServiceTests
{
    [Fact]
    public async Task CreateUpdateCandidateInfo_ShouldUpdateCandidate_WhenCandidateExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JobCandidateHubDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        var mockDbOptions = new Mock<IDbOptions>();
        mockDbOptions.SetupGet(x => x.ConOptions).Returns(options);

        var existingCandidate = new TblCandidate
        {
            Id = Guid.NewGuid(),
            FirstName = "Old",
            LastName = "Name",
            EmailAddress = "existinguser@example.com",
            Comment = "Old comment",
            CallTimeInterval = "Old time",
            GithubUrl = "http://oldgithub.com",
            LinkedInUrl = "http://oldlinkedin.com",
            PhoneNo = "1234567890"
        };

        var model = new CandidateInfoModel
        {
            FirstName = "Updated",
            LastName = "Name",
            EmailAddress = "existinguser@example.com",
            Comment = "Updated comment",
            CallTimeInterval = "Updated time",
            GithubUrl = "http://updatedgithub.com",
            LinkedInUrl = "http://updatedlinkedin.com",
            PhoneNo = "9876543210"
        };

        await using (var context = new JobCandidateHubDbContext(options))
        {
            context.TblCandidates.Add(existingCandidate);
            await context.SaveChangesAsync();
        }

        // Act
        Guid updatedCandidateId;
        await using (var context = new JobCandidateHubDbContext(options))
        {
            var service = new CandidateService(mockDbOptions.Object);
            updatedCandidateId = await service.CreateUpdateCandidateInfo(model);
        }

        // Assert
        await using (var context = new JobCandidateHubDbContext(options))
        {
            var candidate = await context.TblCandidates.FindAsync(updatedCandidateId);
            Assert.NotNull(candidate);
            Assert.Equal("Updated", candidate.FirstName);
            Assert.Equal("Updated time", candidate.CallTimeInterval);
        }
    }

    [Fact]
    public async Task CreateUpdateCandidateInfo_ShouldCreateCandidate_WhenCandidateDoesNotExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<JobCandidateHubDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        var mockDbOptions = new Mock<IDbOptions>();
        mockDbOptions.SetupGet(x => x.ConOptions).Returns(options);

        var model = new CandidateInfoModel
        {
            FirstName = "New",
            LastName = "User",
            EmailAddress = "newuser@example.com",
            Comment = "New comment",
            CallTimeInterval = "9-5",
            GithubUrl = "http://github.com/newuser",
            LinkedInUrl = "http://linkedin.com/newuser",
            PhoneNo = "1234567890"
        };

        // Act
        Guid newCandidateId;
        await using (var context = new JobCandidateHubDbContext(options))
        {
            var service = new CandidateService(mockDbOptions.Object);
            newCandidateId = await service.CreateUpdateCandidateInfo(model);
        }

        // Assert
        await using (var context = new JobCandidateHubDbContext(options))
        {
            var candidate = await context.TblCandidates.FindAsync(newCandidateId);
            Assert.NotNull(candidate);
            Assert.Equal("New", candidate.FirstName);
            Assert.Equal("newuser@example.com", candidate.EmailAddress);
        }
    }
}