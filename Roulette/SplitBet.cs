using System;
using System.Collections.Generic;

namespace Gamling
{
    /// <summary>
    /// Constructor without parameters
    /// </summary>
    public class SplitBet : Bet
    {
        public SplitBet() : base("Split", 17)
        {
        }

        public List<int> Numbers { get; private set; }

        /// <summary>
        /// Method sets the bet
        /// </summary>
        /// <param name="obj">value of the bet</param>
        public override void Set(object obj)
        {
            this.Numbers = obj as List<int>;

            this.ListValidation(this.Numbers);
        }

        /// <summary>
        /// Method for determine the fact of victory
        /// </summary>
        /// <param name="number">Interger number</param>
        /// <param name="colour">red or black</param>
        /// <returns>true(win) or false(lose)</returns>
        public override bool IsWinner(int number, string colour)
        {
            if (this.Numbers.Contains(number))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method allows to compare on equality
        /// instances of this class
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>true(objects are the same) or false(objects are not the same)</returns>
        public override bool Equals(object obj)
        {
            SplitBet bet = obj as SplitBet;

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
            return base.GetHashCode() ^ this.Numbers.GetHashCode();
        }

        /// <summary>
        /// Method 
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"{Numbers[0]}, {Numbers[1]}");
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

        /// <summary>
        /// Method validates numbers in the input list 
        /// </summary>
        /// <param name="numbers">Numbers of cells on the game board</param>
        private void ListValidation(List<int> numbers)
        {
            if (numbers.Count != 2)
            {
                throw new ArgumentException("List must have only two numbers!");
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                this.NumValidation(numbers[i]);

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        throw new ArgumentException("List must have only unique numbers!");
                    }
                }
            }
        }
    }
}
