using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;
using dotnet_api_demo.Repositories;
using dotnet_api_demo.Services;

namespace dotnet_api_demo.Services
{
    public class FootballTeamService : IFootballTeamService
    {
        private readonly IFootballTeamRepository _footballTeamRepository;

        public FootballTeamService(IFootballTeamRepository footballTeamRepository)
        {
            _footballTeamRepository = footballTeamRepository;
        }

        public async Task<List<FootballTeamModel>> GetAllTeamsAsync()
        {
            var teams = await _footballTeamRepository.GetAllTeamsAsync();
            return teams.ToList();
        }

        public async Task<FootballTeamModel?> GetTeamByNameAsync(string teamName)
        {
            return await _footballTeamRepository.GetTeamByNameAsync(teamName);
        }

        public async Task<bool> CreateTeamAsync(FootballTeamModel team)
        {
            await _footballTeamRepository.CreateTeamAsync(team);
            return true;
        }

        public async Task<bool> CreateManyAsync(List<FootballTeamModel> teams)
        {
            return await _footballTeamRepository.CreateManyAsync(teams);
        }

        public async Task<bool> UpdateTeamAsync(string teamName, FootballTeamModel team)
        {
            return await _footballTeamRepository.UpdateTeamAsync(teamName, team);
        }

        public async Task<bool> DeleteTeamAsync(string teamName)
        {
            return await _footballTeamRepository.DeleteTeamAsync(teamName);
        }
    }

    // Stubbed method to retrieve all teams.
    // public async Task<List<FootballTeamModel>> GetAllTeamsAsync()
    // {
    //     await Task.Delay(500);
    //     return new List<FootballTeamModel>
    //     {
    //         new FootballTeamModel { TeamName = "Arizona Cardinals", TeamCity = "Arizona", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Atlanta Falcons", TeamCity = "Atlanta", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Baltimore Ravens", TeamCity = "Baltimore", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Buffalo Bills", TeamCity = "Buffalo", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Carolina Panthers", TeamCity = "Carolina", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Chicago Bears", TeamCity = "Chicago", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Cincinnati Bengals", TeamCity = "Cincinnati", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Cleveland Browns", TeamCity = "Cleveland", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Dallas Cowboys", TeamCity = "Dallas", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Denver Broncos", TeamCity = "Denver", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Detroit Lions", TeamCity = "Detroit", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Green Bay Packers", TeamCity = "Green Bay", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Houston Texans", TeamCity = "Houston", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Indianapolis Colts", TeamCity = "Indianapolis", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Jacksonville Jaguars", TeamCity = "Jacksonville", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Kansas City Chiefs", TeamCity = "Kansas City", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Las Vegas Raiders", TeamCity = "Las Vegas", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Los Angeles Chargers", TeamCity = "Los Angeles", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Los Angeles Rams", TeamCity = "Los Angeles", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Miami Dolphins", TeamCity = "Miami", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Minnesota Vikings", TeamCity = "Minnesota", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "New England Patriots", TeamCity = "New England", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "New Orleans Saints", TeamCity = "New Orleans", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "New York Giants", TeamCity = "New York", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "New York Jets", TeamCity = "New York", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Philadelphia Eagles", TeamCity = "Philadelphia", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Pittsburgh Steelers", TeamCity = "Pittsburgh", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "San Francisco 49ers", TeamCity = "San Francisco", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Seattle Seahawks", TeamCity = "Seattle", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Tampa Bay Buccaneers", TeamCity = "Tampa Bay", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Tennessee Titans", TeamCity = "Tennessee", CurrentRoster = new List<FootballPlayerModel>() },
    //         new FootballTeamModel { TeamName = "Washington Commanders", TeamCity = "Washington", CurrentRoster = new List<FootballPlayerModel>() }
    //     };
    // }
}
