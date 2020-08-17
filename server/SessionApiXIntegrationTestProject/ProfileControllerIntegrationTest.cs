using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SessionApiXIntegrationTestProject
{
    public class ProfileControllerIntegrationTest
    {
        private readonly HttpClient _identityHttpClient;
        private readonly HttpClient _sut;

        public ProfileControllerIntegrationTest()
        {
            // Run Identity Server
            var identityHostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<IdentityServer.Startup>();
                });
            var identityHost = identityHostBuilder.Start();
            _identityHttpClient = identityHost.GetTestClient();

            // Run APi server
            var apiHostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<SessionApi.Startup>();
                });
            var apiHost = apiHostBuilder.Start();
            _sut = apiHost.GetTestClient();
        }


        private async Task Setup()
        {
            var tokenResponse = await _identityHttpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5001/connect/token",
                ClientId = "noUserClient",
                ClientSecret = "secret",

                Scope = "sessionapi"
            });

            _sut.SetBearerToken(tokenResponse.AccessToken);

            _sut.BaseAddress = new Uri("https://localhost:6001/");
        }

        [Fact]
        public async Task WhenGetProfile_ProfileReturnedOkay()
        {

            await Setup();
            var expected = "";
            //_sut.BaseAddress = new Uri("https://localhost:6001/");
            var response = await _sut.GetAsync("https://localhost:6001/statistics");
            var content = await response.Content.ReadAsStringAsync();

            response.Should().BeEquivalentTo(expected);
        }
    }
}
