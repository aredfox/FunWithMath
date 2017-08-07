using System.Collections.Generic;
using Xunit;

namespace FunWithMath
{
    public class Factorial
    {
        public int CalcFactorial(int number) {
            if (number == 0) return 1;
            return number * CalcFactorial(number - 1);
        }

        public int CalcFactorialNonRecursive(int number)
        {
            var result = 1;

            for (int i = result; i <= number; i++)
                result *= i;

            return result;
        }

        [Theory]
        [MemberData(nameof(FactorialTestData))]
        public void CalcFactorialTest(int position, int expected) {
            Assert.Equal(expected, CalcFactorial(position));
        }

        [Theory]
        [MemberData(nameof(FactorialTestData))]
        public void CalcFactorialNonRecursiveTest(int position, int expected)
        {
            Assert.Equal(expected, CalcFactorialNonRecursive(position));
        }

        public static IEnumerable<object[]> FactorialTestData() {
            yield return new object[] { 0, 1 };
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 2 };
            yield return new object[] { 3, 6 };
            yield return new object[] { 4, 24 };
            yield return new object[] { 5, 120 };
            yield return new object[] { 6, 720 };
            yield return new object[] { 7, 5040 };
            yield return new object[] { 8, 40320 };
            yield return new object[] { 9, 362880 };
            yield return new object[] { 10, 3628800 };
            yield return new object[] { 11, 39916800 };
        }
    }
}
