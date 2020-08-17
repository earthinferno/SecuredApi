using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SessionApi.Controllers;
using SessionApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SessionApiXUnitTestProject.SessionAPI
{
    public class StatisticsControllerUnitTests
    {
        private readonly StatisticsController _sut;

        public StatisticsControllerUnitTests()
        {
            _sut = new StatisticsController();
        }

        [Fact]
        public void WhenGetIsInvoked_StatisticsDataIsReturned()
        {
            var expected = new SessionStats
            {
                UserSessions = new UserSessions
                { 
                    Logons = 42,
                }
            };

            var result = _sut.Index() as JsonResult;

            result.Value.Should().BeEquivalentTo(expected);
        }

    }
}
