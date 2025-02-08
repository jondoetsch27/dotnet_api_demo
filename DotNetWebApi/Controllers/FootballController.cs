using dotnet_api_demo.Models;
using dotnet_api_demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FootballController(IFootballPlayerService footballPlayerService, IFootballTeamService footballTeamService) : ControllerBase
{
    private readonly IFootballPlayerService _footballPlayerService = footballPlayerService;
    private readonly IFootballTeamService _footballTeamService = footballTeamService;

    [HttpGet("teams")]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _footballTeamService.GetAllTeamsAsync();
        return Ok(teams);
    }

    [HttpGet("teams/{teamName}")]
    public async Task<IActionResult> GetTeamByName(string teamName)
    {
        var team = await _footballTeamService.GetTeamByNameAsync(teamName);
        if (team == null) { return NotFound($"Team '{teamName}' not found."); }
        return Ok(team);
    }

    [HttpPost("teams")]
    public async Task<IActionResult> CreateTeam([FromBody] FootballTeamModel team)
    {
        if (team == null) { return BadRequest("Invalid team data."); }
        await _footballTeamService.CreateTeamAsync(team);
        return CreatedAtAction(nameof(GetTeamByName), new { teamName = team.TeamName }, team);
    }

    [HttpPost("teams/bulk")]
    public async Task<IActionResult> CreateManyTeams([FromBody] List<FootballTeamModel> teams)
    {
        if (teams == null || teams.Count == 0) { return BadRequest("Invalid teams data."); }
        await _footballTeamService.CreateManyAsync(teams);
        return Ok("Teams created successfully.");
    }

    [HttpPut("teams/{teamName}")]
    public async Task<IActionResult> UpdateTeam(string teamName, [FromBody] FootballTeamModel updatedTeam)
    {
        var success = await _footballTeamService.UpdateTeamAsync(teamName, updatedTeam);
        if (!success) { return NotFound($"Team '{teamName}' not found."); }
        return Ok($"Team '{teamName}' updated successfully.");
    }

    [HttpDelete("teams/{teamName}")]
    public async Task<IActionResult> DeleteTeam(string teamName)
    {
        var success = await _footballTeamService.DeleteTeamAsync(teamName);
        if (!success) { return NotFound($"Team '{teamName}' not found."); }
        return Ok($"Team '{teamName}' deleted successfully.");
    }

    [HttpGet("players")]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = await _footballPlayerService.GetAllPlayersAsync();
        return Ok(players);
    }

    [HttpGet("players/{id}")]
    public async Task<IActionResult> GetPlayerById(string id)
    {
        var player = await _footballPlayerService.GetPlayerByIdAsync(id);
        if (player == null) { return NotFound($"Player with ID '{id}' not found."); }
        return Ok(player);
    }

    [HttpPost("players")]
    public async Task<IActionResult> CreatePlayer([FromBody] FootballPlayerModel player)
    {
        if (player == null) { return BadRequest("Invalid player data."); }
        await _footballPlayerService.CreatePlayerAsync(player);
        return Ok("Player created successfully.");
    }

    [HttpPost("players/bulk")]
    public async Task<IActionResult> CreateManyPlayers([FromBody] List<FootballPlayerModel> players)
    {
        if (players == null || players.Count == 0) { return BadRequest("Invalid players data."); }
        await _footballPlayerService.CreateManyAsync(players);
        return Ok("Players created successfully.");
    }

    [HttpPut("players/{id}")]
    public async Task<IActionResult> UpdatePlayer(string id, [FromBody] FootballPlayerModel updatedPlayer)
    {
        var success = await _footballPlayerService.UpdatePlayerAsync(id, updatedPlayer);
        if (!success) { return NotFound($"Player with ID '{id}' not found."); }
        return Ok($"Player with ID '{id}' updated successfully.");
    }

    [HttpDelete("players/{id}")]
    public async Task<IActionResult> DeletePlayer(string id)
    {
        var success = await _footballPlayerService.DeletePlayerAsync(id);
        if (!success) { return NotFound($"Player with ID '{id}' not found."); }
        return Ok($"Player with ID '{id}' deleted successfully.");
    }
}
