using dotnet_api_demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FootballController : ControllerBase
    {
        private readonly IFootballPlayerService _footballPlayerService;
        private readonly IFootballTeamService _footballTeamService;
        public FootballController(IFootballPlayerService footballPlayerService, IFootballTeamService footballTeamService)
        {
            _footballPlayerService = footballPlayerService;
            _footballTeamService = footballTeamService;
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _footballTeamService.GetAllTeamsAsync();
            return Ok(teams);
        }
    }
}