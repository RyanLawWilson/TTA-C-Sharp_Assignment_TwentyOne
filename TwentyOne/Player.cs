using System;
using System.Collections.Generic;
using System.Text;

// Page 170

namespace TwentyOne
{
    public class Player
    {
        public List<Card> Hand { get; set; }
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
