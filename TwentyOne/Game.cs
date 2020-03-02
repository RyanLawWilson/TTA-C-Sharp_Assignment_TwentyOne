using System;
using System.Collections.Generic;
using System.Text;

// Page 167

namespace TwentyOne
{
    // abstract means that this class can never be instantiated
    public abstract class Game
    {
        public List<string> Players { get; set; }
        public string Name { get; set; }
        public string Dealer { get; set; }

        // virtual methods can only be in abstract classes, they have implementation and can be overriden
        // Allows you to customize this method in a child class
        public virtual void ListPlayers()
        {
            foreach (string player in Players)
            {
                Console.WriteLine(player);
            }
        }

        // abstract method can only exists in abstract class.  Contains no implementation
        // Any class inheriting this class must implement this method.
        public abstract void Play();
    }
}
