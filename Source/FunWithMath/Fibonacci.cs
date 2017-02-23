using System.Collections.Generic;
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

        [Theory]
        [MemberData(nameof(FibonacciTestData))]
        public void PowerOfTest(int position, int expected) {
            Assert.Equal(expected, CalcFibonacci(position));
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
