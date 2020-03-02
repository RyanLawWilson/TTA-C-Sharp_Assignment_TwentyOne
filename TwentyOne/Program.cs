using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // Card card = new Card() { Face = "King", Suit = "Spades" };  // Initialization quickly.

            TwentyOneGame game = new TwentyOneGame() { Dealer = "Ryan", Name = "Twenty One"};
            game.Players = new List<string>() { "Bob", "Joe", "Smith" };

            game.ListPlayers();     // Calling the superclass method.  Game is the superclass and you are calling it's method.

            game.Play();        // Implement this later

            Console.Read();
            //Deck deck = new Deck();
            //deck.Shuffle(3);

            //foreach (Card card in deck.Cards)
            //{
            //    Console.WriteLine(card.Face + " of " + card.Suit);
            //}

            //Console.ReadLine();
        }
    }
}
