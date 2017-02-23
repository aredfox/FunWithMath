using System.Collections.Generic;
using Xunit;

namespace FunWithMath
{
    public class IsPrime
    {
        public bool CalcIsPrime(int number) {
            if (number == 0) return false;
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (var i = 2; i < number; i++) {
                if (number % i == 0) return false;
            }

            return true;
        }

        [Theory]
        [MemberData(nameof(PrimeNumberTestData))]
        public void CalcIsPrimeTest(int number, bool expected) {
            Assert.Equal(expected, CalcIsPrime(number));
        }

        public static IEnumerable<object[]> PrimeNumberTestData() {
            yield return new object[] { 0, false };
            yield return new object[] { 1, false };
            yield return new object[] { 2, true };
            yield return new object[] { 3, true };
            yield return new object[] { 4, false };
            yield return new object[] { 5, true };
            yield return new object[] { 6, false };
            yield return new object[] { 7, true };
            yield return new object[] { 8, false };
            yield return new object[] { 9, false };
            yield return new object[] { 10, false };
            yield return new object[] { 11, true };
            yield return new object[] { 23, true };
            yield return new object[] { 31, true };
            yield return new object[] { 571, true };
            yield return new object[] { 853, true };
            yield return new object[] { 854, false };
            yield return new object[] { 997, true };
            yield return new object[] { 999, false };
        }
    }
}
