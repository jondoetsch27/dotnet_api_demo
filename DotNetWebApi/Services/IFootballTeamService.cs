using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_demo.Services 
{
    public interface IFootballPlayerService
    {
        Task<string> GetPlayerDetailsAsync(int playerId);
        Task<string> GetPlayerStatsAsync(int playerId);
        Task<List<string>> GetAllPlayersInTeamAsync(int teamId);
    }
}
