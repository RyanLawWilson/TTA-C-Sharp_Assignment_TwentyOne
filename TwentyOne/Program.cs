using System;

// Page 203

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // When you get to a large project, use different namespaces and sub-namespaces

            Console.Write("Welcome to the Grand Hotel and Casino.  Let's start by giving me your name:  ");
            string playerName = Console.ReadLine();

            Console.Write("How much money did you bring to wast-- SPEND today?  ");
            int bank = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hello, {0}.  Would you like to play 21?  ", playerName);
            string answer = Console.ReadLine().ToLower();

            // If the user wants to play 21, add them to the players list and play the game.
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "yup" || answer == "ya" || answer == "true" || answer == "t" || answer == "tru")
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;                                 // The player has an overloaded operator that allows the player to be added to the players List using the + operator.
                
                // Only play the game is the player is playing and has money
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();                // Logic for the game will be mostly in this method
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }

            Console.WriteLine("\nFeel free to look around... Actually, GET OUT!");
            Console.WriteLine("*You were kicked out of the casino*");
            Console.Read();
        }
    }
}
