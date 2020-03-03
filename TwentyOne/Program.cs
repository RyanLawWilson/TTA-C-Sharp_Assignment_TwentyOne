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

            // x represent each element => means where, Condition.  ex: (x where x.Face == Face.Ace)
            // x => can be thought of as: "For each item x"
            //int count = deck.Cards.Count(x => x.Face == Face.Ace);              //Count is a Lambda function

            //List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();

            List<int> numberList = new List<int> { 1, 4, 561, 41, 2, 3, 123, 990, 122 };
            int sum = numberList.Sum(x => x + 5);
            sum = numberList.Where(x => x > 20).Sum();

            Console.WriteLine(sum);

            deck.Shuffle(3);

            //foreach (Card card in deck.Cards)
            //{
            //    ConsoleColor color = card.Suit == Suit.Hearts || card.Suit == Suit.Diamonds ? ConsoleColor.Red : ConsoleColor.DarkCyan;

            //    Console.WriteLine("{0,-6} of {1,9}", card.Face, card.Suit, Console.ForegroundColor = color);
            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }
    }
}
