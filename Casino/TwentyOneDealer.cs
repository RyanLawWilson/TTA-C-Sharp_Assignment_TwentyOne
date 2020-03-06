using System.Collections.Generic;

namespace Casino.TwentyOne
{
    public class TwentyOneDealer : Casino.Dealer
    {
        public TwentyOneDealer ()
        {
            Hand = new List<Card>();
        }

        public bool Stay { get; set; }
        public bool IsBusted { get; set; }
        public List<Card> Hand { get; set; }
    }
}
