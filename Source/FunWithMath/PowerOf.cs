﻿using System.Collections.Generic;
using Xunit;

namespace FunWithMath
{
    public class PowerOf
    {
        public int CalcPowerOf(int @base, int exponent) {
            if (@base == 0) { return 0; }
            if (exponent == 0) { return 1; }
            return @base * CalcPowerOf(@base, exponent - 1);
        }

        [Theory]
        [MemberData(nameof(PowerOfTestData))]
        public void PowerOfTest(int @base, int exponent, int expected) {
            Assert.Equal(expected, CalcPowerOf(@base, exponent));
        }

        public static IEnumerable<object[]> PowerOfTestData() {
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 0, 1, 0 };
            yield return new object[] { 2, 0, 1 };
            yield return new object[] { 2, 1, 2 };
            yield return new object[] { 2, 2, 4 };
            yield return new object[] { 5, 2, 25 };
            yield return new object[] { 5, 3, 125 };
            yield return new object[] { 5, 4, 625 };
        }
    }
}
