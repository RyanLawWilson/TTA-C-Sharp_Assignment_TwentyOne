using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino.TwentyOne
{
    // This class is to contain logic specific to BlackJack
    public static class TwentyOneRules
    {
        // The convention for private variables is to start the name with _ (underscore)
        // We are hard coding the values because these values will never change.
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Ace] = 1,     // Adding logic to this later
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
        };

        /*
            PROBLEM WITH THIS: You cannot inherit from a struct.
            What might be easier is if we make a TwentyOneCard class that has the properties of Card and has the additional
            property of value.Set the initially Ace value to 11.  The logic would be:

            if (Hand is bust and Hand has ace) then set one ace to 1, check Hand again.Do this for every ace in hand.
            if all aces in Hand are 1 and hand is still bust, you lose.

            This logic would be in this class in a method called isBusted.  Returns bool: true = Hand is bust, false = Keep playing
        */

        //Returns the possible values of a hand when the hand has an Ace.  (Ace, Card) ==> 2 Values, (Ace, Ace, Card) ==> 3 values
        private static int[] GetAllPossibleHandValues(List<Card> Hand)
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace);
            int[] result = new int[aceCount + 1];

            int value = Hand.Sum(x => _cardValues[x.Face]);
            result[0] = value;

            // If there are no aces, just return the result
            if (result.Length == 1) return result;

            // At least 1 Ace in Hand
            for (int i = 0; i < result.Length; i++)
            {
                // i starts at 0, so i * 10 = 0 ==> nothing changes.  Every iteration of i after that represents changing an
                // Ace value from 1 to 11 (a difference of 10, hence i * 10).
                value += i * 10;
                result[i] = value;
            }

            return result;
        }

        // Checks the hand for BlackJack
        public static bool CheckForBlackJack(List<Card> Hand)
        {
            // Find the maximum Hand value
            int value = GetAllPossibleHandValues(Hand).Max();

            // If the max hand is 21, it's a BlackJack
            return value == 21 ? true : false;
        }

        // Checks to see if the Hand is busted
        public static bool IsBusted(List<Card> hand)
        {
            // Get the smallest value from the 
            int value = GetAllPossibleHandValues(hand).Min();

            // If the hand value is more than 21, bust
            return value > 21 ? true : false;
        }

        // Determines is the dealer should stay
        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);

            // Look at all of the possible values
            foreach (int value in possibleHandValues)
            {
                // If the value is between 17 and 21, stay
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }

            return false;
        }

        // Compare the dealer and player hands if neither of them busted.
        public static bool? CompareHands(List<Card> playerHand, List<Card> dealerHand)
        {
            int[] playerResults = GetAllPossibleHandValues(playerHand);
            int[] dealerResults = GetAllPossibleHandValues(dealerHand);

            // We want to find the scores that are 21 or lower and find the largest one of those.
            // Try catch not necessary for playerScore because when the player gets > 21 they bust and don't compare to dealer.
            int playerScore;
            int dealerScore;

            // If the Lambda expression are valid, find the player's best score for comparison.
            // && playerResults.Where(x => x < 22) != null
            if (playerResults.Where(x => x < 22).Count() > 0) playerScore = playerResults.Where(x => x < 22).Max();
            else playerScore = playerResults.Where(x => x < 100).Max();

            if (dealerResults.Where(x => x < 22).Count() > 0) dealerScore = dealerResults.Where(x => x < 22).Max();
            else dealerScore = dealerResults.Where(x => x < 100).Max();

            // Compare the scores
            if (playerScore > dealerScore) return true;
            if (playerScore < dealerScore) return false;
            return null;
        }

    }
}
