using System.Collections.Generic;
using Xunit;

namespace FunWithMath
{
    public class SumArray
    {
        public int CalcSumArray(int[] array, int? count = null) {
            if (!count.HasValue) { count = array.Length; }
            if (count == 0) return 0;
            return array[count.Value - 1] + CalcSumArray(array, count - 1);
        }

        [Theory]
        [MemberData(nameof(SumArrayTestData))]
        public void CalcSumArrayTest(int[] array, int expected) {
            Assert.Equal(expected, CalcSumArray(array));
        }

        public static IEnumerable<object[]> SumArrayTestData() {
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 55 };
            yield return new object[] { new int[] { 10, 9, 10, 8, 10, 7, 10, 6, 10 }, 80 };
            yield return new object[] { new int[] { 6, 5, 4, 3, 2, 1 }, 21 };
        }
    }
}
