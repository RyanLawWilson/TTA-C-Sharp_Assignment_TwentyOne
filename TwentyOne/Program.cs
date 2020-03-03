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
            Card card = new Card();
            card.Suit = Suit.Clubs;     // Using an enum to assign the Card's suit.

            int underlyingValue = (int)Suit.Diamonds;   // enums have an underlying integer value.
            Console.WriteLine(underlyingValue);

            Deck deck = new Deck();
            deck.Shuffle(3);

            //foreach (Card card in deck.Cards)
            //{
            //    Console.WriteLine(card.Face + " of " + card.Suit);
            //}

            Console.WriteLine("{0}", deck.Cards.Count, Console.ForegroundColor = ConsoleColor.Red); //ConsoleColor is an Enum
            Console.ReadLine();
        }
    }
}
