using NHLSystemClassLibrary;

ReadPlayerFromCSV();

static void ReadPlayerFromCSV()
{
    Team sampleTeam = new Team(Conference.Western, Division.Pacific, "Oilers", "Edmonton", "Rogers Place");
    using (StreamReader sr = new StreamReader(@"..\..\..\..\DATA\Players.csv"))
    {
        sr.ReadLine();
        string line;
        byte playerParsed = 1;
        while((line = sr.ReadLine()) != null)
        {
            try
            {
                Player currentPlayer;
                Player.TryParse(line, out currentPlayer);
                sampleTeam.Players.Add(currentPlayer);
            }
            catch
            {
                Console.WriteLine($"Player {playerParsed} failed to read");
            }
            playerParsed++;
        }
    }

    Console.WriteLine($"Team Name: {sampleTeam.Name}, Team City: {sampleTeam.City}, Team Conference: {sampleTeam.Conference}, Team Division: {sampleTeam.Division}, Team Arena: {sampleTeam.Arena}");
    foreach(Player player in sampleTeam.Players)
    {
        Console.WriteLine(player.ToString());
    }
}
