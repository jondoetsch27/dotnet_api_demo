using dotnet_api_demo.Services;
using dotnet_api_demo.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
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
