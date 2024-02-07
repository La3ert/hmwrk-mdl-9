//Переведи выводимый текст на украинский язык
namespace StickGame
{
    class Program
    {
        static int stickCount = 10;
        static int sticks;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the stick game! The rules are simple: you and the machine take turns taking " +
                              "1-3 sticks from a pile of sticks. The person who takes the last stick loses." +
                              "\nLet's start!");
            Console.WriteLine("If you want to choose the number of sticks, enter 1. ELse enter 0.");
            int choice;
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    if (choice == 1 || choice == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 0.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
            if (choice == 1)
            {
                stickValue();
            }

            while (stickCount > 0)
            {
                PlayerTurn();
                if (stickCount == 0)
                {
                    Console.WriteLine("You lose!");
                    break;
                }
                MachineTurn();
                if (stickCount == 0)
                {
                    Console.WriteLine("You win!");
                    break;
                }
            }

            Console.ReadKey();
        }
        
        public static void PlayerTurn()
        {
            Console.Write("Enter number of sticks to take: ");

            while (true)
            {
                try
                {
                    sticks = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
            if (sticks < 1 || sticks > 3)
            {
                Console.WriteLine("Invalid number of sticks. Please enter a number between 1 and 3.");
                PlayerTurn();
            }
            else
            {
                stickCount -= sticks;
                Console.WriteLine("There are " + stickCount + " sticks left.");
            }
        }
        
        public static void MachineTurn()
        {
            Random rand = new Random();
            sticks = rand.Next(1, 3);
            Console.WriteLine("The machine took " + sticks + " sticks.");
            stickCount -= sticks;
            Console.WriteLine("There are " + stickCount + " sticks left.");
        }
        
        public static void stickValue()
        {
            Console.Write("Enter number of sticks to start the game: ");
            while (true)
            {
                try
                {
                    stickCount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    if (stickCount < 10)
                    {
                        Console.WriteLine("The number of sticks must be at least 10.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
        }
    }
}