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
            Deck deck = new Deck();
            deck.Shuffle(3);

            foreach (Card card in deck.Cards)
            {
                ConsoleColor color = card.Suit == Suit.Hearts || card.Suit == Suit.Diamonds ? ConsoleColor.Red : ConsoleColor.DarkCyan;

                Console.WriteLine("{0,-6} of {1,9}", card.Face, card.Suit, Console.ForegroundColor = color);
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(deck.Cards.Count); 
            Console.ReadLine();
        }
    }
}
