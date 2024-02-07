namespace ChessPlayer;

public class ChessPlayer
{
    public string Country { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rating { get; set; }
    public int BirthYear { get; set; }
    public int Id { get; set; }
    public int Rank { get; set; }
    public int Games { get; set; }

    public override string ToString()
    {
        return $"Full name: {FirstName} {LastName}, Country: {Country}, Rating: {Rating}, born in: {BirthYear}, Id: {Id}, Rank: {Rank}, Games: {Games}";
    }
        
    public static ChessPlayer ParseFideCvs(string line)
    {
        string[] parts = line.Split(';');
        return new ChessPlayer
        {
            Rank = int.Parse(parts[0]),
            LastName = parts[1].Split(',')[0].Trim(),
            FirstName = parts[1].Split(',')[1].Trim(),
            Country = parts[3],
            Rating = int.Parse(parts[4]),
            BirthYear = int.Parse(parts[6])
        };
    }
        
}