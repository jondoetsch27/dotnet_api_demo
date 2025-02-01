using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;

namespace dotnet_api_demo.Repositories
{
    public interface IFootballTeamRepository
    {
        Task<IEnumerable<FootballTeamModel>> GetAllTeamsAsync();
        Task<FootballTeamModel?> GetTeamByNameAsync(string teamName);
        Task<bool> CreateTeamAsync(FootballTeamModel team);
        Task<bool> UpdateTeamAsync(string teamName, FootballTeamModel team);
        Task<bool> DeleteTeamAsync(string teamName);
        Task<bool> CreateManyAsync(List<FootballTeamModel> teams);
    }
}