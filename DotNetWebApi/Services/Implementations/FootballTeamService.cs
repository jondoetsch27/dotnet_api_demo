using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;
using dotnet_api_demo.Repositories;
using dotnet_api_demo.Services;

namespace dotnet_api_demo.Services.Implementations
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
}
