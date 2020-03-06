using System;
using System.Collections.Generic;

// Page 167

namespace Casino
{
    // abstract means that this class can never be instantiated
    public abstract class Game
    {
        // Initialize the Collections when you create a game.
        public Game ()
        {
            Players = new List<Player>();
            Bets = new Dictionary<Player, int>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public Dictionary<Player, int> Bets { get; set; }

        // virtual methods can only be in abstract classes, they have implementation and can be overriden
        // Allows you to customize this method in a child class
        public virtual void ListPlayers()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }

        // abstract method can only exists in abstract class.  Contains no implementation
        // Any class inheriting this class must implement this method.
        public abstract void Play();
    }
}
