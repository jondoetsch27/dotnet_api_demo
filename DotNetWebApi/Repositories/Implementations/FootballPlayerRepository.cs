using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Repositories;
using dotnet_api_demo.Models;

namespace dotnet_api_demo.Repositories.Implementations 
{
    public class FootballPlayerRepository : IFootballPlayerRepository
    {
        private readonly IMongoCollection<FootballPlayerModel> _footballPlayers;

        public FootballPlayerRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Testing");
            _footballPlayers = database.GetCollection<FootballPlayerModel>("FootballPlayers");
        }

        public async Task<IEnumerable<FootballPlayerModel>> GetAllAsync()
        {
            return await _footballPlayers.Find(_ => true).ToListAsync();
        }

        public async Task<FootballPlayerModel?> GetByIdAsync(string id)
        {
            return await _footballPlayers.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAsync(FootballPlayerModel player)
        {
            await _footballPlayers.InsertOneAsync(player);
            return true;
        }

        public async Task<bool> UpdateAsync(string id, FootballPlayerModel player)
        {
            var result = await _footballPlayers.ReplaceOneAsync(p => p.Id == id, player);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _footballPlayers.DeleteOneAsync(p => p.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<bool> CreateManyAsync(List<FootballPlayerModel> players)
        {
            await _footballPlayers.InsertManyAsync(players);
            return true;
        }
    }
}
