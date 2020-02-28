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

            Deck shuffledDeck = Shuffle(deck);
            Console.WriteLine(shuffledDeck.Cards.Count);
            foreach (Card card in shuffledDeck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }

            Console.ReadLine();
        }

        // Shuffles the deck of cards. | Page 154
        public static Deck Shuffle(Deck deck)
        {
            //Jesse's shuffled list mehtod
            List<Card> tempList = new List<Card>();
            Random rand = new Random();

            while (deck.Cards.Count > 0)
            {
                int randomIndex = rand.Next(0, deck.Cards.Count);
                tempList.Add(deck.Cards[randomIndex]);
                deck.Cards.RemoveAt(randomIndex);
            }

            deck.Cards = tempList;
            return deck;


            //My Shuffle method
            //Random rand = new Random();
            //Deck shuffledDeck = new Deck();
            //shuffledDeck.Cards.Clear();

            //int cardsLeft = deck.Cards.Count;
            //while (cardsLeft > 0)
            //{
            //    int indexOfCard = rand.Next(0, cardsLeft - 1);
            //    Card card = deck.Cards[indexOfCard];

            //    shuffledDeck.Cards.Add(card);
            //    deck.Cards.Remove(card);

            //    cardsLeft = deck.Cards.Count;
            //}

            //return shuffledDeck;
        }
    }
}
