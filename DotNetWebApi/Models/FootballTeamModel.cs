using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_api_demo.Models 
{
    public class FootballTeamModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public List<FootballPlayerModel> CurrentRoster { get; set; }
    }
}