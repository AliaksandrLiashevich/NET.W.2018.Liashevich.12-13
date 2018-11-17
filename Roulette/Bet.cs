namespace Gamling
{
    /// <summary>
    /// Class describes structure of the bet and allows
    /// inheritance to realize definite kind of the bet 
    /// </summary>
    public abstract class Bet
    {
        protected const int NumCount = 36;
        protected readonly int RateCoeff;
        
        /// <summary>
        /// Constructor initializes general parameters
        /// for every kind of the bet
        /// </summary>
        /// <param name="name">Name of definite bet</param>
        /// <param name="_rateCoeff">Defines win coefficient</param>
        public Bet(string name, int _rateCoeff)
        {
            Name = name;
            RateCoeff = _rateCoeff;
        }

        public string Name { get; private set; }

        /// <summary>
        /// Method defines the logics of bet
        /// definition
        /// </summary>
        /// <param name="obj">Object represent bet</param>
        public abstract void Set(object obj);

        /// <summary>
        /// Method for determine the fact of victory
        /// </summary>
        /// <param name="number">Interger number</param>
        /// <param name="colour">red or black</param>
        /// <returns>true(win) or false(lose)</returns>
        public abstract bool IsWinner(int number, string colour);

        /// <summary>
        /// Method calculates win sum according
        /// to rate and rate coefficients of definite rate
        /// </summary>
        /// <param name="rate">Value of the rate</param>
        /// <returns>Won sum</returns>
        public double WonSum(double rate)
        {
            return rate * RateCoeff;
        }

        /// <summary>
        /// Method allows to compare on equality
        /// instances of this class
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>true(objects are the same) or false(objects are not the same)</returns>
        public override bool Equals(object obj)
        {
            return Name.Equals(Name) &
                RateCoeff.Equals(RateCoeff);
        }

        /// <summary>
        /// Method generates psevdo-unique code
        /// for quick compare objects
        /// </summary>
        /// <returns>Integer number</returns>
        public override int GetHashCode()
        {
            return (Name + RateCoeff.ToString()).GetHashCode();
        }

        /// <summary>
        /// Method 
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            return string.Format($"Name: {Name} RateCoeff: {RateCoeff}");
        }
    }   
}
