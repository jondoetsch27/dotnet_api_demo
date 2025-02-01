using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;
using dotnet_api_demo.Repositories;
using dotnet_api_demo.Services;

namespace dotnet_api_demo.Services
{
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly IFootballPlayerRepository _footballPlayerRepository;
        public FootballPlayerService(IFootballPlayerRepository footballPlayerRepository)
        {
            _footballPlayerRepository = footballPlayerRepository;
        }

        public async Task<List<FootballPlayerModel>> GetAllPlayersAsync()
        {
            var players = await _footballPlayerRepository.GetAllAsync();
            return players.ToList();
        }

        public async Task<FootballPlayerModel?> GetPlayerByIdAsync(string id)
        {
            return await _footballPlayerRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreatePlayerAsync(FootballPlayerModel player)
        {
            await _footballPlayerRepository.CreateAsync(player);
            return true;
        }

        public async Task<bool> UpdatePlayerAsync(string id, FootballPlayerModel player)
        {
            return await _footballPlayerRepository.UpdateAsync(id, player);
        }

        public async Task<bool> DeletePlayerAsync(string id)
        {
            return await _footballPlayerRepository.DeleteAsync(id);
        }

        public async Task<bool> CreateManyAsync(List<FootballPlayerModel> players)
        {
            await _footballPlayerRepository.CreateManyAsync(players);
            return true;
        }
    }
}
