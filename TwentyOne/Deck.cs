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
    }
}
