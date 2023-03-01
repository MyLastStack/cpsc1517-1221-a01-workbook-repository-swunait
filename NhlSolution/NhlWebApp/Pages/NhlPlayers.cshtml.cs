using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NhlSystemClassLibrary;

namespace NhlWebApp.Pages
{
    public class NhlPlayersModel : PageModel
    {
        public List<Player> PlayerList { get; private set; } = new List<Player>();

        public void OnGet()
        {
            string[] allLines = System.IO.File.ReadAllLines("C:\\Users\\swu\\source\\repos\\cpsc1517-1221-a01-workbook-repository-swunait\\NhlSolution\\NhlWebApp\\wwwroot\\data\\OilersPlayers.csv");
            foreach (var currentLine in allLines)
            {
                try
                {
                    Player currentPlayer = null;
                    if (Player.TryParse(currentLine, out currentPlayer))
                    {
                        PlayerList.Add(currentPlayer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from file with exception {ex.Message}");
                }
            }
        }
    }
}
