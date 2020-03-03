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

        public Suit Suit { get; set; }        //You can 'get' this property or 'set' this property
        public Face Face { get; set; }        //You can 'get' this property or 'set' this property
    }

    // Enums are usually in a different file.  They limit the possible values you can get.
    // Enums have underlying value corresponding to how they are listed.  You can also change it.
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Face
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}
