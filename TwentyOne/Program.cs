using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Overloading operators! Page 182

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new TwentyOneGame();

            Player player = new Player() {Name = "Bob"};
            // Notice that game + player looks like (Game game, Player player) in the Player class + operator
            game = game + player;
            game = game - player;
            Deck deck = new Deck();
            deck.Shuffle(3);

            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }

            Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }
    }
}
