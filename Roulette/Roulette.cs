using System;
using System.Collections.Generic;

namespace Gamling
{
    public class Roulette
    {
        private const int NumCount = 36;
        private List<string> colours = new List<string>() { "red", "black" };

        private RouletteResultHandler win;
        private RouletteResultHandler lose;

        /// <summary>
        /// Constructor that initialize a roulette object
        /// </summary>
        public Roulette()
        {
            Gamblers = new List<Gambler>();
            win = FileLog.WinLog;
            lose = FileLog.LoseLog;
        }

        /// <summary>
        /// Constructor that initialize a roulette object
        /// </summary>
        /// <param name="_gamblers">Array of gamblers</param>
        public Roulette(List<Gambler> _gamblers)
        {
            Gamblers = _gamblers;
        }

        public delegate void RouletteResultHandler(object sender, RouletteResultEventArgs e);

        public List<Gambler> Gamblers { get; private set; }

        /// <summary>
        /// Method allows to add gambler to current game
        /// </summary>
        /// <param name="gambler">Object of class gambler</param>
        public void AddGambler(Gambler gambler)
        {
            Gamblers.Add(gambler);
        }

        /// <summary>
        /// Method allows to remove gambler to current game
        /// </summary>
        /// <param name="id">Individual integer code of a gambler</param>
        public void DeleteGambler(int id)
        {
            IDValidation(id);   

            Gamblers.RemoveAt(id);
        }

        /// <summary>
        /// Method allows to change choice in the range of current bet
        /// </summary>
        /// <param name="id">Individual integer code of a gambler</param>
        /// <param name="obj">Value of the bet</param>
        public void ChangeBet(int id, object obj)
        {
            IDValidation(id);

            Gamblers[id].Bet.Set(obj);
        }

        /// <summary>
        /// Method allows to change value of the rate
        /// </summary>
        /// <param name="id">Individual integer code of a gambler</param>
        /// <param name="rate">Value of rate</param>
        public void ChangeRate(int id, double rate)
        {
            IDValidation(id);

            Gamblers[id].Rate = rate;
        }

        /// <summary>
        /// Method allows to change type of the bet
        /// </summary>
        /// <param name="id">Individual integer code of a gambler</param>
        /// <param name="bet">Type of the bet</param>
        public void ChangeTypeOfBet(int id, Bet bet)
        {
            IDValidation(id);

            Gamblers[id].Bet = bet;
        }

        /// <summary>
        /// Method that runs the game
        /// </summary>
        /// <remarks>Generates number and logs losers and winners</remarks>
        public void StartGame()
        {
            Random rand = new Random();

            int number = rand.Next(0, NumCount);
            int colourNum = rand.Next(0, 1);

            foreach (Gambler gambler in Gamblers)
            {
                RouletteResultEventArgs args = new RouletteResultEventArgs(gambler);

                if (gambler.IsWinner(number, colours[colourNum]))
                {
                    gambler.WonSum();

                    if (win != null)
                    {
                        win(this, args);
                    }
                }
                else
                {
                    gambler.LoseSum();

                    if (lose != null)
                    {
                        lose(this, args);
                    }
                }
            }
        }

        /// <summary>
        /// Method checks exist the gambler in the list or not
        /// </summary>
        /// <param name="id">Individual integer code of a gambler</param>
        private void IDValidation(int id)
        {
            if (id < Gamblers.Count)
            {
                throw new ArgumentException("ID need to be in the range of the gamblers list!");
            }
        }
    }
}
