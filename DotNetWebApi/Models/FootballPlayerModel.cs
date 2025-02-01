using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_api_demo.Models
{
    public class FootballPlayerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UniformNumber { get; set; }
        public FootballTeamModel CurrentTeam { get; set; }
        public List<FootballTeamModel> TeamHistory { get; set; }
    }
}