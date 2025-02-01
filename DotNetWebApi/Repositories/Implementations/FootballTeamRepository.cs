using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_demo.Models;

namespace dotnet_api_demo.Repositories.Implementations
{
    public class FootballTeamRepository : IFootballTeamRepository
    {
        private readonly IMongoCollection<FootballTeamModel> _footballTeams;

        public FootballTeamRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Testing");
            _footballTeams = database.GetCollection<FootballTeamModel>("FootballTeams");
        }

        public async Task<IEnumerable<FootballTeamModel>> GetAllTeamsAsync()
        {
            return await _footballTeams.Find(_ => true).ToListAsync();
        }

        public async Task<FootballTeamModel?> GetTeamByNameAsync(string teamName)
        {
            return await _footballTeams.Find(t => t.TeamName == teamName).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateTeamAsync(FootballTeamModel team)
        {
            await _footballTeams.InsertOneAsync(team);
            return true;
        }

        public async Task<bool> UpdateTeamAsync(string teamName, FootballTeamModel team)
        {
            var result = await _footballTeams.ReplaceOneAsync(t => t.TeamName == teamName, team);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteTeamAsync(string teamName)
        {
            var result = await _footballTeams.DeleteOneAsync(t => t.TeamName == teamName);
            return result.DeletedCount > 0;
        }

        public async Task<bool> CreateManyAsync(List<FootballTeamModel> teams)
        {
            await _footballTeams.InsertManyAsync(teams);
            return true;
        }
    }
}