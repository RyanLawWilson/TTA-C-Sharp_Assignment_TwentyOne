using System;
using System.Collections.Generic;
using System.Text;

// Page 150

namespace TwentyOne
{
    // Represents a deck of standard cards.
    public class Deck
    {
        // Constructor assigns values to properties immediatly upon creation.
        public Deck()
        {
            Cards = new List<Card>();               // Initialize the deck of cards.

            // These are all of the Faces and Suits of each card.
            List<string> Faces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            List<string> Suits = new List<string>() { "Spades", "Clubs", "Hearts", "Diamonds" };

            // Add each card variation to the deck.
            foreach (string face in Faces)
            {
                foreach (string suit in Suits)
                {
                    Card card = new Card();         // Build a new Card
                    card.Suit = suit;               // Set property of Suit
                    card.Face = face;               // Set property of Face
                    Cards.Add(card);                // Add this card to the deck.
                }
            }
        }
        public List<Card> Cards { get; set; }       // A deck is a collection of Cards.  We can get or set the cards.


        // Shuffles the deck of cards. | Page 154 ... Moved to Deck class Page 162
        // out parameters allow you to return more than 1 variable from a method.
        public void Shuffle(int times = 1)    // Optional parameter: int times = 1
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> tempList = new List<Card>();
                Random rand = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = rand.Next(0, Cards.Count);
                    tempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }

                Cards = tempList;
            }
        }
    }
}
