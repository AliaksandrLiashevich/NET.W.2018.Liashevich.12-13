namespace SearchAlgorithms
{
    /// <summary>
    /// Provide compare methods fro different types to define delegate object
    /// </summary>
    public static class CompareMethods
    {
        /// <summary>
        /// Method for compare elements with int type
        /// </summary>
        /// <param name="arg1">first argument</param>
        /// <param name="arg2">second argument</param>
        /// <returns>result of comparison</returns>
        /// <remarks>Algorithm returns: (arg1 = arg2) => (0) ||
        /// (arg1 > arg2) => (1) || (arg1 = arg2) => (-1) </remarks>
        public static int CompareInt(int arg1, int arg2)
        {
            return arg1.CompareTo(arg2);
        }

        /// <summary>
        /// Method for compare elements with string type
        /// </summary>
        /// <param name="arg1">first argument</param>
        /// <param name="arg2">second argument</param>
        /// <returns>result of comparison</returns>
        /// <remarks>Algorithm returns: (arg1 = arg2) => (0) ||
        /// (arg1 > arg2) => (1) || (arg1 = arg2) => (-1) </remarks>
        public static int CompareString(string arg1, string arg2)
        {
            return arg1.CompareTo(arg2);
        }
    }
}
