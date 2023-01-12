using NHLSystemClassLibrary;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team currentTeam = new Team(Conference.Western, Division.Pacific, "Oilers", "Edmonton", "Rogers Place");
            Console.WriteLine($"{currentTeam.City}, {currentTeam.Name}, {currentTeam.Conference}, {currentTeam.Division}, {currentTeam.Arena}");
            Console.ReadLine();
        }
    }
}
