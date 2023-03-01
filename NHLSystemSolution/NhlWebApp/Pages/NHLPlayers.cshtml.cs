using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHLSystemClassLibrary;

namespace NhlWebApp.Pages
{
    public class NHLPlayersModel : PageModel
    {
        public Team? TeamToDisplay { get; set; } = new Team();
        public Player[] Players
        {
            get
            {
                return TeamToDisplay.Players.ToArray();
            }
        }
        string filePath = @"..\DATA\Players.csv";

        public void OnGet()
        {
            ReadPlayerFromCSV(filePath);
        }

        public void ReadPlayerFromCSV(string filePath)
        {
            TeamToDisplay = new Team(Conference.Western, Division.Pacific, "Oilers", "Edmonton", "Rogers Place");
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;
                byte playerParsed = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        Player currentPlayer;
                        Player.TryParse(line, out currentPlayer);
                        TeamToDisplay.Players.Add(currentPlayer);
                    }
                    catch
                    {
                        Console.WriteLine($"Player {playerParsed} failed to read");
                    }
                    playerParsed++;
                }
            }
        }

        public string DisplayPlayer(int index)
        {
            return $"{Players[index].PlayerNo}, {Players[index].Name}, {Players[index].Position}, {Players[index].GamesPlayed}, {Players[index].Goals}, {Players[index].Assists}, {Players[index].Points}";
        }
    }
}
