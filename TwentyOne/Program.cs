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
            Deck deck = new Deck();
            int timesShuffled = 0;      // When shuffle is called, this variable takes the value of timesShuffled (the out parameter)
            deck = Shuffle(deck: deck, out timesShuffled, times: 3);   // Named parameters just make code more readable.

            Console.WriteLine(deck.Cards.Count);
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine("Times Shuffled: {0}", timesShuffled);

            Console.ReadLine();
        }

        // Shuffles the deck of cards. | Page 154
        // out parameters allow you to return more than 1 variable from a method.
        public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1)    // Optional parameter: int times = 1
        {
            timesShuffled = 0;

            for (int i = 0; i < times; i++)
            {
                timesShuffled++;
                List<Card> tempList = new List<Card>();
                Random rand = new Random();

                while (deck.Cards.Count > 0)
                {
                    int randomIndex = rand.Next(0, deck.Cards.Count);
                    tempList.Add(deck.Cards[randomIndex]);
                    deck.Cards.RemoveAt(randomIndex);
                }

                deck.Cards = tempList;
            }
            
            return deck;
        }

        //// Shuffles the deck of cards. | Page 157
        //public static Deck Shuffle(Deck deck, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
