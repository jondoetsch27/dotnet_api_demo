using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;

namespace dotnet_api_demo.Services 
{
    public interface IFootballPlayerService
    {
        Task<List<FootballPlayerModel>> GetAllPlayersAsync();
        Task<FootballPlayerModel?> GetPlayerByIdAsync(string id);
        Task<bool> CreatePlayerAsync(FootballPlayerModel player);
        Task<bool> UpdatePlayerAsync(string id, FootballPlayerModel player);
        Task<bool> DeletePlayerAsync(string id); 
        Task<bool> CreateManyAsync(List<FootballPlayerModel> players);
    }
}
