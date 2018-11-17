using System;

namespace Gamling
{
    public class ParityBet : Bet
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ParityBet() : base("Parity", 2)
        {
        }

        public string Parity { get; private set; }

        /// <summary>
        /// Method sets the bet
        /// </summary>
        /// <param name="obj">value of the bet</param>
        public override void Set(object obj)
        {
            string str = obj as string;

            this.DataValidation(str);

            this.Parity = str;
        }

        /// <summary>
        /// Method for determine the fact of victory
        /// </summary>
        /// <param name="number">Interger number</param>
        /// <param name="colour">red or black</param>
        /// <returns>true(win) or false(lose)</returns>
        public override bool IsWinner(int number, string colour)
        {
            this.DataValidation(colour);

            return this.Parity.Equals(colour);
        }

        /// <summary>
        /// Method allows to compare on equality
        /// instances of this class
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>true(objects are the same) or false(objects are not the same)</returns>
        public override bool Equals(object obj)
        {
            ParityBet bet = obj as ParityBet;

            if (bet != null)
            {
                return base.Equals(obj) & this.Parity.Equals(bet);
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
            return base.GetHashCode() ^ this.Parity.GetHashCode();
        }


        /// <summary>
        /// Method 
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"Parity: {Parity}");
        }

        /// <summary>
        /// Method validates the input object in set method
        /// to avoid errors with invalid type
        /// </summary>
        /// <param name="str">Input value of th bet</param>
        private void DataValidation(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("Instance is not a string!");
            }
            else if (str != "even" && str != "uneven")
            {
                throw new ArgumentException("Instance need another colour!");
            }
        }
    }
}
