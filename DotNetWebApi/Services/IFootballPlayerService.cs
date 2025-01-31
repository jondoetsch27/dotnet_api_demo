using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;

namespace dotnet_api_demo.Services 
{
    public interface IFootballTeamService
    {
        Task<List<FootballTeamModel>> GetAllTeamsAsync();
        Task<string> GetTeamDetailsAsync(int teamId);
        Task<string> GetTeamPerformanceStatsAsync(int teamId);
    }
}
