namespace SearchAlgorithms
{
    public delegate int Comparer<T>(T arg1, T arg2);

    /// <summary>
    /// Binary Search algorithm in generic realization
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Method searches element in the array acording the key
        /// </summary>
        /// <typeparam name="T">universal parameter</typeparam>
        /// <param name="array">array of some elements</param>
        /// <param name="key">parameter for element searching</param>
        /// <param name="comparer">delegate that defines compare logics</param>
        /// <returns>index of element in the array</returns>
        /// <remarks>if element doesn't exist or array is empty, algorithm returns -1</remarks>>
        public static int Search<T>(T[] array, T key, Comparer<T> comparer)
        {
            if (array.Length == 0)
            {
                return -1;
            }

            bool descendingOrder;

            if (comparer(array[0], array[array.Length - 1]) == 1)
            {
                descendingOrder = true;
            }
            else
            {
                descendingOrder = false;
            }

            return SearchLogics(array, key, 0, array.Length, descendingOrder, comparer);
        }

        /// <summary>
        /// Method searches element in the array acording the key
        /// </summary>
        /// <typeparam name="T">universal parameter</typeparam>
        /// <param name="array">array of some elements</param>
        /// <param name="key">parameter for element searching</param>
        /// <param name="left">beginning of subarray in the main array</param>
        /// <param name="right">end of subarray in the main array</param>
        /// <param name="descendingOrder">allows to work alforithm when array has descending order</param>
        /// <param name="comparer">delegate that defines compare logics</param>
        /// <returns>index of element in the array</returns>
        /// <remarks>if element doesn't exist or array is empty, algorithm returns -1</remarks>>
        private static int SearchLogics<T>(T[] array, T key, int left, int right, bool descendingOrder, Comparer<T> comparer)
        {
            int mid = (left + (right - left)) / 2;

            if (left >= right)
            {
                return -1;
            }

            if (comparer(array[mid], key) == 0)
            {
                return mid;
            }
            else if ((comparer(array[mid], key) == 1) ^ descendingOrder)
            {
                return SearchLogics(array, key, left, mid, descendingOrder, comparer);
            }
            else
            {
                return SearchLogics(array, key, mid + 1, right, descendingOrder, comparer);
            }
        }
    }
}
