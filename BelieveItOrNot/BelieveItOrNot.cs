namespace BelieveItOrNot;

public class BelieveItOrNot
{
    public string question {get; set;} = null!;
    public string answer {get; set;} = null!;
    public string explanation {get; set;} = null!;

    public override string ToString()
    {
        return $"Question: {question}";
    }

    public static BelieveItOrNot ParseQuestion(string line)
    {
        string[] parts = line.Split(';');
        return new BelieveItOrNot
        {
            question = parts[0],
            answer = parts[1],
            explanation = parts[2]
        };
    }
}