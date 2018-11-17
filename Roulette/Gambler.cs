namespace Gamling
{
    public class Gambler
    {
        /// <summary>
        /// Constructor to initialize gambler parameters
        /// </summary>
        /// <param name="firstName">First name of the gambler</param>
        /// <param name="lastName">Last name of the gambler</param>
        /// <param name="patronym">Patrinym of the gambler</param>
        /// <param name="bet">Type of the bet</param>
        public Gambler(string firstName, string lastName, string patronym, Bet bet)
        {
            FirstName = firstName;

            LastName = lastName;

            Patronym = patronym;

            Bet = bet;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Patronym { get; private set; }

        public double Sum { get; private set; }

        public double Rate { get; set; }

        public Bet Bet { get; set; }

        /// <summary>
        /// Method for determine the fact of victory
        /// </summary>
        /// <param name="number">Interger number</param>
        /// <param name="colour">red or black</param>
        /// <returns>true(win) or false(lose)</returns>
        public bool IsWinner(int number, string colour)
        {
            return Bet.IsWinner(number, colour);
        }

        /// <summary>
        /// Method calculates win sum according
        /// to rate and rate coefficients of definite rate
        /// </summary>
        /// <param name="rate">Value of the rate</param>
        /// <returns>Won sum</returns>
        public double WonSum()
        {
            Sum += Rate;

            return Bet.WonSum(Rate);
        }
        /// <summary>
        /// Method calculates win sum according
        /// to rate and rate coefficients of definite rate
        /// </summary>
        /// <returns>Lose sum</returns>
        public double LoseSum()
        {
            Sum -= Rate;

            Sum = Sum > 0 ? Sum : 0;

            return Rate;
        }

        /// <summary>
        /// Method allows to compare on equality
        /// instances of this class
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>true(objects are the same) or false(objects are not the same)</returns>
        public override bool Equals(object obj)
        {
            Gambler gambler = obj as Gambler;

            if (gambler != null)
            {
                return FirstName.Equals(gambler.FirstName) & 
                    LastName.Equals(gambler.LastName) &
                    Patronym.Equals(gambler.Patronym) &
                    Rate.Equals(gambler.Rate) &
                    Bet.Equals(gambler.Bet);
            }

            return false;
        }

        /// <summary>
        /// Method generates psevdo-unique code
        /// for quick compare objects
        /// </summary>
        /// <returns>Integer number</returns>
        public override int GetHashCode()
        {
            return (FirstName + LastName + Patronym).GetHashCode();
        }

        /// <summary>
        /// Method 
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            return string.Format($"FirstName: {FirstName} LastName: {LastName} Patronym: {Patronym}" +
                $"Rate: {Rate} Sum: {Sum} + {Bet}");
        }
    }
}
