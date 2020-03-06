using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

// Page 172

namespace TwentyOne
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        // Deals a Card to a Player Hand
        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());
            string card = String.Format(Deck.Cards.First().ToString());
            Console.WriteLine(card);

            // For StreamWriter, the first parameter is path and the second is if you want to append.  Page 216
            // This writes the card to the log.
            // We are opening a stream here.  The using statement will dispose of any memory associated with this process once it is done.
            using (StreamWriter file = new StreamWriter(@"C:\Users\Ryan Wilson\Documents\TechAcademyRepos\TTA Basic C-Sharp Projects\.TwentyOne\TwentyOne\files\log.txt", true))
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(card);
            }

            Deck.Cards.RemoveAt(0);
        }
    }
}
