using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FunWithMath
{
    public class Fibonacci
    {
        public int CalcFibonacci(int position) {
            if (position == 0) { return 0; }
            if (position == 1) { return 1; }
            return CalcFibonacci(position - 1) + CalcFibonacci(position - 2);
        }

        public int CalcFibonacciNonRecursive(int position) {
            var result = new List<int> { 0, 1 };

            for (var i = 2; i <= position; i++)
                result.Add(result.ElementAt(i - 1) + result.ElementAt(i - 2));

            return result.ElementAt(position);                
        }

        [Theory]
        [MemberData(nameof(FibonacciTestData))]
        public void CalcFibonacciTest(int position, int expected) {
            Assert.Equal(expected, CalcFibonacci(position));
        }

        [Theory]
        [MemberData(nameof(FibonacciTestData))]
        public void CalcFibonacciNonRecursiveTest(int position, int expected)
        {
            Assert.Equal(expected, CalcFibonacciNonRecursive(position));
        }

        public static IEnumerable<object[]> FibonacciTestData() {
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 1 };
            yield return new object[] { 3, 2 };
            yield return new object[] { 4, 3 };
            yield return new object[] { 5, 5 };
            yield return new object[] { 6, 8 };
            yield return new object[] { 7, 13 };
            yield return new object[] { 8, 21 };
            yield return new object[] { 9, 34 };
            yield return new object[] { 10, 55 };
            yield return new object[] { 28, 317811 };
        }
    }
}
