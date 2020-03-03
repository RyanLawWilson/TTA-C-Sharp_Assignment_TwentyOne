using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    // Inherit from both Game (class) and IWalkAway (interface)
    public class TwentyOneGame : Game, IWalkAway       // 21 Game INHERITS from Game
    {
        // override means that this method comes from an abstract class.
        public override void Play()
        {
            throw new NotImplementedException();
        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 Players");
            base.ListPlayers();
        }

        // Needs to be here because interface says so.
        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
