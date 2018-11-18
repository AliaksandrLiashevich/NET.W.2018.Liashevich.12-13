using NUnit.Framework;

namespace BinarySearch.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        SearchAlgorithms.Comparer<int> comparerInt = SearchAlgorithms.CompareMethods.CompareInt;
        SearchAlgorithms.Comparer<string> comparerString = SearchAlgorithms.CompareMethods.CompareString;

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, ExpectedResult = 5)]
        [TestCase(new int[] { -98, -18, -3, 0 }, 0, ExpectedResult = 3)]
        [TestCase(new int[] { 987, 521, 123 }, 1, ExpectedResult = -1)]
        [TestCase(new int[] { }, 0, ExpectedResult = -1)]

        public void Search_IntParameters_ElementIndex(int[] array, int key, int expected)
        {
            return SearchAlgorithms.BinarySearch.Search<int>(array, key, comparerInt);
        }

        [TestCase(new string[] { "a", "b", "c", "d", "e", "f" }, "b", ExpectedResult = 1)]
        [TestCase(new string[] { "z", "k", "i", "h", "f", "c", "a" }, "a", ExpectedResult = 6)]
        [TestCase(new string[] { "r", "p", "l" }, "a", ExpectedResult = -1)]
        [TestCase(new string[] { }, "a", ExpectedResult = -1)]

        public int Search_StringParameters_ElementIndex(string[] array, string key)
        {
            return SearchAlgorithms.BinarySearch.Search<string>(array, key, comparerString);
        }
    }
}
