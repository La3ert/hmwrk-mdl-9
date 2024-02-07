namespace ChessPlayer;

class Program
{
    static void Main(string[] args)
    {
        PlayerFilter(@"C:\Users\Admin\RiderProjects\Homework_mdl9\ChessPlayer\Top100ChessPlayers.csv");
    }
    
    static void PlayerFilter(string file)
    {
        IEnumerable<ChessPlayer> list = File.ReadAllLines(file)
            .Skip(1)
            .Select(ChessPlayer.ParseFideCvs)
            .Where(player => player.Country == "RUS")
            .OrderBy(player => player.BirthYear);
        
        foreach (var player in list)
        {
            Console.WriteLine(player);
        }
    }
}

