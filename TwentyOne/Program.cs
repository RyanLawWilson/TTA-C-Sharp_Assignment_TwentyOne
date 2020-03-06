using System;
using System.IO;
using Casino;
using Casino.TwentyOne;

// Page 203

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // When you get to a large project, use different namespaces and sub-namespaces
            Player pl = new Player("Bob");
            // You can use the var keyword to store any data type.

            // Declaring constants
            const string casinoName = "Grand Hotel and Casino";

            // Guid stands for Global Unique Identifier.  It gives you a random unique number that you can use to identify things
            Guid identifier = Guid.NewGuid();

            Console.Write($"Welcome to the {casinoName}.  Let's start by giving me your name:  ");
            string playerName = Console.ReadLine();


            bool invalidAnswer = true;
            int bank = 0;
            while (invalidAnswer)
            {
                Console.Write("How much money did you bring to wast-- SPEND today?  ");
                invalidAnswer = !int.TryParse(Console.ReadLine(), out bank);
                if (invalidAnswer) Console.WriteLine("Please enter digits only with no decimals");
            }


            Console.Write("Hello, {0}.  Would you like to play 21?  ", playerName);
            string answer = Console.ReadLine().ToLower();

            // If the user wants to play 21, add them to the players list and play the game.
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "yup" || answer == "ya" || answer == "true" || answer == "t" || answer == "tru")
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;                                 // The player has an overloaded operator that allows the player to be added to the players List using the + operator.
                player.ID = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"C:\Users\Ryan Wilson\Documents\TechAcademyRepos\TTA Basic C-Sharp Projects\.TwentyOne\Casino\files\log.txt", true))
                {
                    file.WriteLine(player.ID);
                }

                // Only play the game is the player is playing and has money
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play();                // Logic for the game will be mostly in this method
                    }
                    catch (FraudException)
                    {
                        Console.WriteLine("Security, this person has negative money!");
                        Console.Read();
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occured.  Please contact system admin (good luck)");
                        Console.Read();
                        return;
                    }
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
