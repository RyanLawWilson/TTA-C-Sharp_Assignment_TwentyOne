// Page 

namespace Casino.Interfaces  // Making a subnamespace
{
    // You can only inherit 1 base class in .NET, but you can inherit as many interfaces as you want.
    // Interfaces always start the name with capital 'i'
    interface IWalkAway
    {
        // Everything is public in an interface
        // Anything inherited from IWalkAway must implement this method
        void WalkAway(Player player);
    }
}