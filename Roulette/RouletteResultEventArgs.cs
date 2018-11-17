using System;

namespace Gamling
{
    /// <summary>
    /// Class provide additional information about event
    /// </summary>
    public class RouletteResultEventArgs : EventArgs 
    {
        /// <summary>
        /// Constructor for initialization of object
        /// </summary>
        /// <param name="gambler">Instance of class Gambler</param>
        public RouletteResultEventArgs(Gambler gambler)
        {
            Gambler = gambler;
        }

        public Gambler Gambler { get; private set; }
    }
}
