using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    public class TwentyOneDealer : Dealer
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
