using System;
using System.IO;

namespace Gamling
{
    /// <summary>
    /// Class provide methods to log different events in a simple text file
    /// </summary>
    public static class FileLog
    {
        private static string winPath = "WinLog";
        private static string losePath = "LoseLog";

        /// <summary>
        /// Method-listener of win event
        /// </summary>
        /// <param name="sender">Object-parent of event</param>
        /// <param name="args">Object helper with additional data of the event</param>
        /// <remarks>Write all information about gamblers into file</remarks>
        public static void WinLog(object sender, RouletteResultEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("Instanse with additional data is null!");
            }

            using (StreamWriter writer = new StreamWriter(winPath, true, System.Text.Encoding.Default))
            {
                writer.Write(args.Gambler);
            }
        }

        /// <summary>
        /// Method-listener of lose event
        /// </summary>
        /// <param name="sender">Object-parent of event</param>
        /// <param name="args">Object helper with additional data of the event</param>
        /// <remarks>Write all information about gamblers into file</remarks>
        public static void LoseLog(object sender, RouletteResultEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("Instanse with additional data is null!");
            }

            using (StreamWriter writer = new StreamWriter(winPath, true, System.Text.Encoding.Default))
            {
                writer.Write(args.Gambler);
            }
        }
    }
}
