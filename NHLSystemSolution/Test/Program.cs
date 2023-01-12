using NHLSystemClassLibrary;
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team oilers = new Team(Conference.Western, Division.Pacific, "Oilers", "Edmonton", "Rogers Place");
            Console.WriteLine($"{oilers.City}, {oilers.Name}, {oilers.Conference}, {oilers.Division}, {oilers.Arena}");
            Console.ReadLine();
        }
    }
}