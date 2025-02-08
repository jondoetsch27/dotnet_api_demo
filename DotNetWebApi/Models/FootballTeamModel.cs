using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_api_demo.Models;

public record FootballTeamModel(
    string TeamName,
    string TeamCity,
    List<FootballPlayerModel>? CurrentRoster = null,
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string Id = ""
);
