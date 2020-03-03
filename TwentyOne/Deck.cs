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

            // i represents Faces
            for (int i = 0; i < 13; i++)
            {
                // j represents Suits
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();

                    // You can cast an Enum to an integer ==> (int) Face.Ace to get the underlying index value ==> 0.
                    // Also, you can cast an integer to an Enum ==> (Face) 0 to get the string value ==> Ace.

                    card.Face = (Face)i;
                    card.Suit = (Suit)j;
                    Cards.Add(card);
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
