using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_api_demo.Models;

public record FootballPlayerModel(
    string FirstName,
    string LastName,
    string UniformNumber,
    FootballTeamModel? CurrentTeam = null,
    List<FootballTeamModel>? TeamHistory = null,
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string Id = ""
);
