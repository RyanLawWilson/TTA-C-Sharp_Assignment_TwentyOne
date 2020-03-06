using System;
using System.Collections.Generic;
using System.Linq;
using Casino.Interfaces;

namespace Casino.TwentyOne
{
    // Inherit from both Game (class) and IWalkAway (interface)
    public class TwentyOneGame : Game, IWalkAway       // 21 Game INHERITS from Game and the interface IWalkAway
    {
        /*
            Why can't I use polymorphism here.  I thought that saying Dealer Dealer = new TwentyOneDealer(); would allow me to have the properties
            of both Dealer and TwentyOneDealer.  It doesn't work that way, however.  I only have access to the Dealer class' properties, not
            the TwentyOneDealer properties.  I need both, though...

            Writing TwentyOneDealer Dealer = new TwentyOneDealer(); gives me all of the properties that I need for Dealer.  That's great but why
            then would I ever need to say something like Game game = new TwentyOneGame();
        */
        public TwentyOneDealer Dealer { get; set; }

        // override means that this method comes from an abstract class.
        // This is the 21 game.  This is one hand. (one playthrough)
        public override void Play()
        {
            /***********************************
             * S T A R T - Initial Deal and Bet
             ***********************************/

            // First, make a dealer
            Dealer = new TwentyOneDealer();

            // At the beginning of the game reset all of the necessary values.
            foreach (Player player in Players)
            {
                player.Hand.Clear();
                player.Stay = false;
            }

            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();

            Dealer.Deck.Shuffle(3);

            Console.Write("Place your bet: ");

            // Each player places a bet
            foreach (Player player in Players)
            {
                int bet = Convert.ToInt32(Console.ReadLine());
                bool successfullyBet = player.Bet(bet);

                if (!successfullyBet)
                {
                    return;     // Saying return will end the method.
                }

                // Add an association between the player and their bet using the Dictionary ( located in Game )
                Bets[player] = bet;
            }

            // Each player gets dealt 2 cards
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing... ");

                // Give each player 1 card.
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);

                    // If the player got a 21 with 2 cards (i == 1), it's a BlackJack.  Pay them.
                    // THIS DEVIATES FROM THE VIDEO a little.  But I think the performance will be the same.  If C# is anything like Java,
                    // When the program sees the first condition (i == 1), evaluates it to false, then looks at the logical operator &&,
                    // It will skip the if statement, not checking for BlackJack.  This looks cleaner.
                    if (i == 1 && TwentyOneRules.CheckForBlackJack(player.Hand))
                    {
                        Console.WriteLine("BlackJack!  {0} wins {1}", player.Name, Bets[player]);

                        // The player gets their bet back and wins 1.5 times their bet.
                        player.Balance += Convert.ToInt32(2.5 * Bets[player]);
                        return;
                    }
                }

                Console.Write("Dealer: ");
                Dealer.Deal(Dealer.Hand);

                // If the dealer got a 21 with 2 cards (i == 1), it's a BlackJack.  Collect bets.
                if (i == 1 && TwentyOneRules.CheckForBlackJack(Dealer.Hand))
                {
                    Console.Write("Dealer has BlackJack!  Everyone Loses.  Dealer got paid ");

                    // This is how you iterate through a dictionary
                    // The dealer wins all of the player's bets.
                    //foreach (KeyValuePair<Player,int> entry in Bets)
                    //{
                    //    Dealer.Balance += entry.Value;
                    //}

                    // Lambda expression that does the same thing above because he mentioned there might be a way in the video: there is.

                    Dealer.Balance += Bets.Sum(x => x.Value);

                    Console.WriteLine("{0}!", Dealer.Balance);

                    return;
                }
            }

            /********************************
             * E N D - Initial Deal and Bet
             ********************************/

            /**********************************
             * S T A R T - Hitting and Staying
             **********************************/

            // Each player is going to keep hitting until they stay (or bust?)
            foreach (Player player in Players)
            {
                // This player will keep getting the opportunity to hit until they stay.
                bool busted = false;
                while (!player.Stay && !busted)        // Added && to fix infinite loop if you busted.
                {
                    Console.Write("Your cards are ");

                    // Show all of the player's cards.
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0} ", card.ToString());
                    }
                    Console.Write("\n\nHit or Stay: ");
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "stay" || answer == "sty" || answer == "sta" || answer == "say" || answer == "sat" || answer == "s" || answer == "st")
                    {
                        player.Stay = true;
                        break;
                    }
                    else
                    {
                        Dealer.Deal(player.Hand);
                    }

                    // Did the player bust?
                    busted = TwentyOneRules.IsBusted(player.Hand);

                    // If the player busted, they lose their bet to the dealer.
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted! You lose your bet of {1}.  Your balance is {2}.", player.Name, Bets[player], player.Balance);
                        Console.Write("Do you want to play again?  ");
                        answer = Console.ReadLine().ToLower();

                        // If they say yes, keep playing.  If they say no, set one of the game loop conditions to false.
                        if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "yup" || answer == "ya" || answer == "true" || answer == "t" || answer == "yep")
                        {
                            player.isActivelyPlaying = true;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                        }

                        return;
                    }
                }
            }

            Dealer.IsBusted = TwentyOneRules.IsBusted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.IsBusted)
            {
                Console.WriteLine("Dealer is Hitting....");
                Dealer.Deal(Dealer.Hand);
                Dealer.IsBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            }

            if (Dealer.Stay) Console.WriteLine("Dealer is staying");

            // The dealer lost!
            if (Dealer.IsBusted)
            {
                Console.WriteLine("Dealer Busted");

                // Pay the players
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);

                    // A Lambda expression to get the balance of the players and add their winnings
                    Players.Where(x => x == entry.Key).First().Balance += entry.Value * 2;

                    Dealer.Balance -= entry.Value;

                    return;
                }
            }

            /*******************************
             * E N D - Hitting and Staying
             *******************************/

            /*******************************
             * S T A R T - Comparing Hands
             *******************************/

            // If no one busted, compare hands
            foreach (Player player in Players)
            {
                // The ? allows the struct bool to be nullable.  Returns null if there is a tie.
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);

                if (playerWon == null)
                {
                    Console.WriteLine("Push!  No one wins!");
                    player.Balance += Bets[player];
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += Bets[player] * 2;
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("The dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }

                // Ask to players if they want to play again.
                Console.Write("Play Again?  ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "yup" || answer == "ya" || answer == "true" || answer == "t" || answer == "yep")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }
        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 Players: ");
            base.ListPlayers();
        }

        // Needs to be here because interface says so.
        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }


}
