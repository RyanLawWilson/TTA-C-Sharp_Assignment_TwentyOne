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


            // Using Polymorphism, you can put different types of games into a list.
            // Child class can morph into parent class.
            Game game = new TwentyOneGame();        // 21 Game MORPHES into Game
            List<Game> games = new List<Game>();
            games.Add(game);


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
