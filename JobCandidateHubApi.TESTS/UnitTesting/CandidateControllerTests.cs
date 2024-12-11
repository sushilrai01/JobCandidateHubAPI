using JobCandidateHubAPI.Controllers;
using JobCandidateHubAPI.Models;
using JobCandidateHubAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JobCandidateHubApi.TESTS.UnitTesting;

public class CandidateControllerTests
{
    private readonly Mock<ICandidateService> _mockCandidateService;
    private readonly JobCandidateController _controller;

    public CandidateControllerTests()
    {
        _mockCandidateService = new Mock<ICandidateService>();
        _controller = new JobCandidateController(_mockCandidateService.Object);
    }

    [Fact]
    public async Task CreateUpdateCandidate_ShouldReturnOk_WhenServiceReturnsGuid()
    {
        // Arrange
        var model = new CandidateInfoModel
        {
            FirstName = "Test",
            LastName = "User",
            EmailAddress = "testuser@example.com",
            Comment = "Test comment",
            CallTimeInterval = "9-5",
            GithubUrl = "http://github.com/testuser",
            LinkedInUrl = "http://linkedin.com/testuser",
            PhoneNo = "1234567890"
        };

        var expectedId = Guid.NewGuid();

        _mockCandidateService
            .Setup(service => service.CreateUpdateCandidateInfo(model))
            .ReturnsAsync(expectedId);

        // Act
        var result = await _controller.CreateUpdateCandidate(model);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedId, okResult.Value);
    }
}