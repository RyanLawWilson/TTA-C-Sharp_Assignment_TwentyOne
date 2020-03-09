using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + "\n");
                }
                Console.Read();
                return;
            }


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
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDBWtihException(ex);
                        Console.Read();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured.  Please contact system admin (good luck)");
                        UpdateDBWtihException(ex);
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

        // Reads all of the exceptions that are stored in tkhe database
        private static List<ExceptionEntity> ReadExceptions()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            string queryString = @"SELECT * FROM Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                // We are using a select statement so we want to read what comes back.
                SqlDataReader reader = command.ExecuteReader();

                // While there is still stuff to read... Convert the record into a c# object
                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception);
                }

                connection.Close();
            }

            // Return the list of exceptions
            return Exceptions;
        }

        // Uses ADO.NET to connect to database
        private static void UpdateDBWtihException(Exception ex)
        {
            // A string that has all of the information for connection to the database.
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            string queryString = @"
                                INSERT INTO Exceptions
                                (ExceptionType, ExceptionMessage, TimeStamp)
                                VALUES
                                (@ExceptionType, @ExceptionMessage, @TimeStamp)";   // Set up to use paramaterized queries

            // using will only open the connection for as long as we are in the {}
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Naming the data type this way protects against SQL injections! Paramaterized queries.
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                // Set the values of this insert.
                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();  // INSERT is a nonquery.
                connection.Close();
            }
        }
    }
}