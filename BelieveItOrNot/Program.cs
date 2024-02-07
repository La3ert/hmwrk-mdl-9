namespace BelieveItOrNot;

class Program 
{ 
    static string? playerAnswer;
    
    static void Main(string[] args) 
    {
        BelieveIt(@"C:\Users\Admin\RiderProjects\Homework_mdl9\BelieveItOrNot\Questions.csv");
        Console.ReadLine();
    }        
    
    static void BelieveIt(string file)
    {
        bool playerWin = true;
        int tries = 0;
        IEnumerable<BelieveItOrNot> list = File.ReadAllLines(file)
            .Skip(1)
            .Select(BelieveItOrNot.ParseQuestion)
            .OrderBy(question => question.question);
        
        foreach (var question in list)
        {
            Console.WriteLine(question);
            playerAnswer = Console.ReadLine();
            while (playerAnswer != "Yes" && playerAnswer != "No")
            {
                Console.WriteLine("Enter Yes if you believe it or No if you don't believe it");
                playerAnswer = Console.ReadLine();
            }
            if (tries < 2)
            {
                if (playerAnswer == question.answer)
                {
                    Console.WriteLine("It is true");
                }
                else
                {
                    Console.WriteLine("You made a mistake");
                    Console.WriteLine(question.explanation);
                    ++tries;
                }
            }
            if(tries == 2)
            {
                Console.WriteLine("You have reached the maximum number of tries. You lose.");
                playerWin = false;
                break;
            }
        }
        if (playerWin)
        {
            Console.WriteLine("You win!");
        }
    }
}

