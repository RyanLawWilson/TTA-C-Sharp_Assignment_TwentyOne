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
            //Card cardOne = new Card();

            //Console.WriteLine(cardOne.Face + " of " + cardOne.Suit);

            //cardOne.Face = "Queen";
            //cardOne.Suit = "Spades";

            //Console.WriteLine(cardOne.Face + " of " + cardOne.Suit);



            //Console.WriteLine("\n\n\n");



            Deck deck = new Deck();

            Console.WriteLine(deck.Cards.Count);

            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }

            Console.ReadLine();
        }
    }
}
