using System;
using System.Linq;
using System.Text;
using Xunit;

namespace FunWithMath
{
    public class Palindrome
    {
        public bool IsPalindrome(string candidate) {
            if (String.IsNullOrWhiteSpace(candidate))
                return false;

            var unreversed = candidate.ToLower().Trim();
            
            if(unreversed[0] != unreversed[unreversed.Length-1])
                return false;

            var reversed = Reverse(unreversed);

            return reversed == unreversed;            
        }

        private string Reverse(string candidate)
        {
            var reversed = candidate.Select((character, index) => new { index, character })
                .OrderByDescending(x => x.index)
                .Select(x => x.character);

            return new String(reversed.ToArray());
        }

        [Theory]
        [InlineData("Palindrome", "emordnilaP")]
        [InlineData("Palindrome", "emordnilaP")]
        public void CanReverseString(string candidate, string expected)
        {
            Assert.Equal(expected, Reverse(candidate));
        }

        [Theory]
        [InlineData("Noon")]
        [InlineData("Refer")]
        [InlineData("Civic")]
        [InlineData("Racecar")]        
        public void ReturnsTrueWhenPalindrome(string candidate)
        {
            Assert.True(IsPalindrome(candidate));
        }

        [Theory]
        [InlineData("Palindrome")]
        public void ReturnsFalseWhenNotAPalindrome(string candidate)
        {            
            Assert.False(IsPalindrome(candidate));
        }        
    }
}
