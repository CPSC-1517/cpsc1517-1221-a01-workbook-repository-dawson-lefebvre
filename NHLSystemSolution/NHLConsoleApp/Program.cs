using NHLSystemClassLibrary;
using System.Security;
using System.Text.Json;

const string JSON_FILEPATH = @"..\..\..\..\DATA\Team.json";
Team sampleTeam = ReadTeamFromJSON(JSON_FILEPATH);
DisplayTeam(sampleTeam);
//ReadPlayerFromCSV(ref sampleTeam);
//WriteTeamToJSON(sampleTeam, JSON_FILEPATH);



static void ReadPlayerFromCSV(ref Team sampleTeam)
{
    sampleTeam = new Team(Conference.Western, Division.Pacific, "Oilers", "Edmonton", "Rogers Place");
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

    DisplayTeam(sampleTeam);
}

static void DisplayTeam(Team sampleTeam)
{
    Console.WriteLine($"Team Name: {sampleTeam.Name}, Team City: {sampleTeam.City}, Team Conference: {sampleTeam.Conference}, Team Division: {sampleTeam.Division}, Team Arena: {sampleTeam.Arena}");
    foreach (Player player in sampleTeam.Players)
    {
        Console.WriteLine(player.ToString());
    }
}

static void WriteTeamToJSON(Team currentTeam, string jsonFilePath)
{
    try
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        string jsonString = JsonSerializer.Serialize<Team>(currentTeam, options);
        File.WriteAllText(jsonFilePath, jsonString);
        Console.WriteLine("JSON write was successful");
    }
    catch(Exception ex)
    {
        Console.WriteLine($"JSON write failed with exception {ex.Message}");
    }
}

static Team ReadTeamFromJSON(string jsonFilePAth)
{
    try
    {
        string jsonString = File.ReadAllText(jsonFilePAth);
        Team currentTeam = JsonSerializer.Deserialize<Team>(jsonString);
        return currentTeam;
    }
    catch(Exception ex)
    {
        throw new Exception($"JSON write failed with exception {ex.Message}");
    }

}
