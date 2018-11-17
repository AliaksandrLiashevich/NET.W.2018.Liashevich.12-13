namespace FibobacciNumbersGenerator
{   
    /// <summary>
    /// Provide method for calculation Fibonacci numbers
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Method calculates Fibonacci number with certain index
        /// </summary>
        /// <param name="n">index of element in the Fibonacci row</param>
        /// <returns>Fibonacci number</returns>
        static decimal Fibonacci(decimal n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
