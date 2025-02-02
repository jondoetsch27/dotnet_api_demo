using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using dotnet_api_demo.Models;
using dotnet_api_demo.Controllers;
using dotnet_api_demo.Services;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_demo.Tests
{
    [TestFixture]
    public class FootballControllerTests
    {
        private IFootballTeamService _footballTeamService;
        private IFootballPlayerService _footballPlayerService;
        private FootballController _controller;

        [SetUp]
        public void SetUp()
        {
            var footballTeamServiceMock = new Mock<IFootballTeamService>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();

            footballTeamServiceMock.Setup(service => service.GetAllTeamsAsync())
                .ReturnsAsync(new List<FootballTeamModel>
                {
                    new FootballTeamModel { TeamCity = "Arizona", TeamName = "Cardinals", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Atlanta", TeamName = "Falcons", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Baltimore", TeamName = "Ravens", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Buffalo", TeamName = "Bills", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Carolina", TeamName = "Panthers", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Chicago", TeamName = "Bears", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Cincinnati", TeamName = "Bengals", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Cleveland", TeamName = "Browns", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Dallas", TeamName = "Cowboys", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Denver", TeamName = "Broncos", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Detroit", TeamName = "Lions", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Green Bay", TeamName = "Packers", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Houston", TeamName = "Texans", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Indianapolis", TeamName = "Colts", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Jacksonville", TeamName = "Jaguars", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Kansas City", TeamName = "Chiefs", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Las Vegas", TeamName = "Raiders", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Los Angeles", TeamName = "Chargers", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Los Angeles", TeamName = "Rams", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Miami", TeamName = "Dolphins", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Minnesota", TeamName = "Vikings", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "New England", TeamName = "Patriots", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "New Orleans", TeamName = "Saints", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "New York", TeamName = "Giants", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "New York", TeamName = "Jets", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Philadelphia", TeamName = "Eagles", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Pittsburgh", TeamName = "Steelers", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "San Francisco", TeamName = "49ers", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Seattle", TeamName = "Seahawks", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Tampa Bay", TeamName = "Buccaneers", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Tennessee", TeamName = "Titans", CurrentRoster = new List<FootballPlayerModel>() },
                    new FootballTeamModel { TeamCity = "Washington", TeamName = "Commanders", CurrentRoster = new List<FootballPlayerModel>() }
                });

            _footballTeamService = footballTeamServiceMock.Object;
            _footballPlayerService = footballPlayerServiceMock.Object;
            _controller = new FootballController(_footballPlayerService, _footballTeamService);
        }

        [Test]
        public async Task GetAllTeams_ReturnsOkResult_WithTeams()
        {
            var result = await _controller.GetAllTeams();
            var okResult = result as OkObjectResult;
            okResult.ShouldNotBeNull();
            
            var teams = okResult.Value as List<FootballTeamModel>;
            teams.ShouldNotBeNull();
            teams.Count.ShouldBe(32);
        }
    }
}