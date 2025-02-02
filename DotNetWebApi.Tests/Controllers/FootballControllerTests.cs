using NUnit.Framework;
using Mongo2Go;
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
        private MongoDbRunner _mongoDbRunner;
        private IFootballTeamService _footballTeamService;
        private IFootballPlayerService _footballPlayerService;
        private FootballController _controller;

        [SetUp]
        public void SetUp()
        {
            _mongoDbRunner = MongoDbRunner.Start();
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

        footballPlayerServiceMock.Setup(service => service.GetAllPlayersAsync())
            .ReturnsAsync(new List<FootballPlayerModel>
            {
                new FootballPlayerModel
                {
                    FirstName = "Nico", 
                    LastName = "Collins", 
                    UniformNumber = "4", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Texans", TeamCity = "Houston" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Texans", TeamCity = "Houston" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "CJ", 
                    LastName = "Stroud", 
                    UniformNumber = "7", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Texans", TeamCity = "Houston" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Texans", TeamCity = "Houston" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "JJ", 
                    LastName = "McCarthy", 
                    UniformNumber = "9", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Vikins", TeamCity = "Minnesota" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Vikings", TeamCity = "Minnesota" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "Blake", 
                    LastName = "Corum", 
                    UniformNumber = "30", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Lions", TeamCity = "Detroit" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Lions", TeamCity = "Detroit" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "Jaxon", 
                    LastName = "Smith Njigba", 
                    UniformNumber = "11", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Seahawks", TeamCity = "Seattle" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Seahawks", TeamCity = "Seattle" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "Garrett", 
                    LastName = "Wilson", 
                    UniformNumber = "17", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Jets", TeamCity = "New York" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Jets", TeamCity = "New York" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "Chris", 
                    LastName = "Olave", 
                    UniformNumber = "12", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Saints", TeamCity = "New Orleans" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Saints", TeamCity = "New Orleans" } }
                },
                new FootballPlayerModel
                {
                    FirstName = "Marvin", 
                    LastName = "Harrison Jr", 
                    UniformNumber = "18", 
                    CurrentTeam = new FootballTeamModel { TeamName = "Cardinals", TeamCity = "Arizona" }, 
                    TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Cardinals", TeamCity = "Arizona" } }
                }
            });

            _footballTeamService = footballTeamServiceMock.Object;
            _footballPlayerService = footballPlayerServiceMock.Object;
            _controller = new FootballController(_footballPlayerService, _footballTeamService);
        }

        [TearDown]
        public void TearDown()
        {
            _mongoDbRunner?.Dispose();
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

        [Test]
        public async Task GetAllPlayers_ReturnsOkResult_WithPlayers()
        {
            var result = await _controller.GetAllPlayers();
            var okResult = result as OkObjectResult;
            okResult.ShouldNotBeNull();

            var players = okResult.Value as List<FootballPlayerModel>;
            players.ShouldNotBeNull();
            players.Count.ShouldBe(8);
        }
    }
}