using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SessionApi.Controllers;
using SessionApi.Models;
using SessionService;
using SessionService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SessionApiXUnitTestProject.SessionAPI
{
    public class ProfileControllerUnitTests
    {
        private readonly Mock<IUserSession> _mockUserSession;

        private const string _name = "mockName";
        private const string _organization = "mockOrganization";
        private const string _email = "mockEmail";

        private readonly ProfileController _sut;

        public ProfileControllerUnitTests()
        {
            _mockUserSession = new Mock<IUserSession>();

            var sessionProfile = new SessionProfile
            {
                Name = _name,
                Organization = _organization,
                Email = _email
            };

            _mockUserSession.Setup(x => x.GetSessionProfile()).Returns(sessionProfile);

            _sut = new ProfileController(_mockUserSession.Object);
        }

        [Fact]
        public void WhenGetIsInvoked_StatisticsDataIsReturned()
        {
            var expected = new Profile
            {
                Name = _name,
                Organization = _organization,
                Email = _email
            };

            var result = _sut.Index() as JsonResult;

            result.Value.Should().BeEquivalentTo(expected);
        }
    }
}
