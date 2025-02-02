using Mongo2Go;
using Microsoft.AspNetCore.Mvc;
using dotnet_api_demo.Models;
using dotnet_api_demo.Controllers;
using dotnet_api_demo.Services;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_api_demo.Tests.XUnit
{
    public class FootballControllerTests
    {
        private IFootballTeamService _footballTeamService;
        private IFootballPlayerService _footballPlayerService;
        private FootballController _controller;

        public FootballControllerTests()
        {
            var footballTeamServiceMock = new Mock<IFootballTeamService>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();

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
                        CurrentTeam = new FootballTeamModel { TeamName = "Vikings", TeamCity = "Minnesota" }, 
                        TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Vikings", TeamCity = "Minnesota" } }
                    },
                    new FootballPlayerModel
                    {
                        FirstName = "Blake", 
                        LastName = "Corum", 
                        UniformNumber = "30", 
                        CurrentTeam = new FootballTeamModel { TeamName = "Rams", TeamCity = "Los Angeles" }, 
                        TeamHistory = new List<FootballTeamModel> { new FootballTeamModel { TeamName = "Rams", TeamCity = "Los Angeles" } }
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

        [Fact]
        public async Task GetAllPlayers_ReturnsOkResult_WithPlayers()
        {
            var result = await _controller.GetAllPlayers();
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);

            var players = okResult.Value as List<FootballPlayerModel>;
            Assert.NotNull(players);
            Assert.Equal(8, players.Count);
        }
    }
}