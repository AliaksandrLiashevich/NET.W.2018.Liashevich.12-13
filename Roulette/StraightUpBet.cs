using System;

namespace Gamling
{
    public class StraightUpBet : Bet
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public StraightUpBet() : base("Straight Up", 35)
        {
        }

        public int Number { get; private set; }

        /// <summary>
        /// Method sets the bet
        /// </summary>
        /// <param name="obj">value of the bet</param>
        public override void Set(object obj)
        {
            this.Number = (int)obj;

            this.NumValidation(this.Number);
        }

        /// <summary>
        /// Method for determine the fact of victory
        /// </summary>
        /// <param name="number">Interger number</param>
        /// <param name="colour">red or black</param>
        /// <returns>true(win) or false(lose)</returns>
        public override bool IsWinner(int number, string colour)
        {
            return this.Number.Equals(number);
        }


        /// <summary>
        /// Method allows to compare on equality
        /// instances of this class
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>true(objects are the same) or false(objects are not the same)</returns>
        public override bool Equals(object obj)
        {
            StraightUpBet bet = obj as StraightUpBet;

            if (bet != null)
            {
                return base.Equals(obj);
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
            return base.GetHashCode() ^ this.Number.GetHashCode();
        }

        /// <summary>
        /// Method 
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"Number: {Number}");
        }

        /// <summary>
        /// Method checks is the number on the definite range
        /// </summary>
        /// <param name="number">Integer value(depends on max roulette cells)</param>
        private void NumValidation(int number)
        {
            if (number < 0 || number > Bet.NumCount)
            {
                throw new ArgumentException("Number has invalid value!");
            }
        }
    }
}
