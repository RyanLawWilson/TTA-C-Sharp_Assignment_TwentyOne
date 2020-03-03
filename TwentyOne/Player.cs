using System;
using System.Collections.Generic;
using System.Text;

// Page 170

namespace TwentyOne
{
    public class Player // <T> to make this class to make it generic (accepts a data type upon creation)
    {
        public List<Card> Hand { get; set; }    // Change to List<T> if class is generic.  Allows players to have different kinds of lists, not just cards.
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }

        // Overloading the + operator.  We want to do Game + Player to add a player
        public static Game operator+ (Game game, Player player)
        {
            game.Players.Add(player);
            return game;
        }

        // The - will remove a player from the game.
        public static Game operator- (Game game, Player player)
        {
            game.Players.Remove(player);
            return game;
        }
    }
}
