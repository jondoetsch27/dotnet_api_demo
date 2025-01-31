namespace dotnet_api_demo.Models 
{
    public class FootballTeamModel
    {
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public List<FootballPlayerModel> CurrentRoster { get; set; }
    }
}