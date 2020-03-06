
// Page 148

namespace Casino
{
    // Represents a Card in a standard deck of cards
    // We make Card struct because nothing inherits from card and we want the value-type functionality Page 195
    public struct Card
    {
        // Public makes things accessable to other classes

        public Suit Suit { get; set; }        //You can 'get' this property or 'set' this property
        public Face Face { get; set; }        //You can 'get' this property or 'set' this property

        // When you print a Card, this text will show.
        public override string ToString()
        {
            //ConsoleColor color = Suit == Suit.Hearts || Suit == Suit.Diamonds ? ConsoleColor.Red : ConsoleColor.DarkCyan;
            return string.Format("{0} of {1}", Face, Suit); ;
        }

        // TESTING PURPOSES.
        public void setFace(Face face)
        {
            Face = face;
        }
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
