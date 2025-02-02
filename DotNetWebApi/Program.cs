using dotnet_api_demo.Services;
using dotnet_api_demo.Services.Implementations;
using dotnet_api_demo.Repositories;
using dotnet_api_demo.Repositories.Implementations;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: true);
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    return new MongoClient(connectionString);
});
builder.Services.AddScoped<IFootballTeamRepository, FootballTeamRepository>();
builder.Services.AddScoped<IFootballPlayerRepository, FootballPlayerRepository>();
builder.Services.AddScoped<IFootballTeamService, FootballTeamService>();
builder.Services.AddScoped<IFootballPlayerService, FootballPlayerService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
