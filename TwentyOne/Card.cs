using System;
using System.Collections.Generic;
using System.Text;

// Page 148

namespace TwentyOne
{
    // Represents a Card in a standard deck of cards
    public class Card
    {
        // Public makes things accessable to other classes

        // Constructor:
        public Card()
        {
            Suit = "Spades";
            Face = "2";
        }

        public string Suit { get; set; }        //You can 'get' this property or 'set' this property
        public string Face { get; set; }        //You can 'get' this property or 'set' this property
    }
}
