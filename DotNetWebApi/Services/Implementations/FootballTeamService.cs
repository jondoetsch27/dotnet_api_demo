using dotnet_api_demo.Models;
using dotnet_api_demo.Repositories;

namespace dotnet_api_demo.Services.Implementations;

public class FootballTeamService(IFootballTeamRepository footballTeamRepository) : IFootballTeamService
{
    private readonly IFootballTeamRepository _footballTeamRepository = footballTeamRepository;

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
