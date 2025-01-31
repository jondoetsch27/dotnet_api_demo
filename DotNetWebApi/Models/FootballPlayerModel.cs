namespace dotnet_api_demo.Models
{
    public class FootballPlayerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UniformNumber { get; set; }
        public FootballTeamModel CurrentTeam { get; set; }
        public List<FootballTeamModel> TeamHistory { get; set; }
    }
}