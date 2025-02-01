using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;

namespace dotnet_api_demo.Repositories
{
    public interface IFootballPlayerRepository
    {
        Task<IEnumerable<FootballPlayerModel>> GetAllAsync();
        Task<FootballPlayerModel?> GetByIdAsync(string id);
        Task<bool> CreateAsync(FootballPlayerModel player);
        Task<bool> UpdateAsync(string id, FootballPlayerModel player);
        Task<bool> DeleteAsync(string id);
        Task<bool> CreateManyAsync(List<FootballPlayerModel> players);
    }
}
