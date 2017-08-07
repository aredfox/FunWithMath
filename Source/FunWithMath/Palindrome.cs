using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace FunWithMath
{
    public class Palindrome
    {
        public bool IsPalindrome(string candidate) {
            if (String.IsNullOrWhiteSpace(candidate))
                return false;

            var unreversed = Clean(candidate);
            
            if(unreversed[0] != unreversed[unreversed.Length-1])
                return false;

            var reversed = Reverse(unreversed);

            return reversed == unreversed;            
        }

        private string Clean(string candidate)
        {
            var cleanedString = candidate;
            cleanedString = cleanedString.ToLower().Trim();

            return new String(cleanedString
                .Where(c => Char.IsLetterOrDigit(c))
                .ToArray()
            );
        }

        private string Reverse(string candidate)
        {
            var reversed = candidate.Select((character, index) => new { index, character })
                .OrderByDescending(x => x.index)
                .Select(x => x.character);

            return new String(reversed.ToArray());
        }

        [Theory]        
        [InlineData("Never odd or even", "neveroddoreven")]
        [InlineData("A man, a plan, a canal - Panama!", "amanaplanacanalpanama")]
        public void CleansAString(string candidate, string expected)
        {
            Assert.Equal(expected, Clean(candidate));
        }

        [Theory]
        [InlineData("Palindrome", "emordnilaP")]
        [InlineData("Palindrome", "emordnilaP")]
        [InlineData("Neveroddoreven", "neveroddoreveN")]
        public void CanReverseString(string candidate, string expected)
        {
            Assert.Equal(expected, Reverse(candidate));
        }

        [Theory]
        [InlineData("Noon")]
        [InlineData("Refer")]
        [InlineData("Civic")]
        [InlineData("Racecar")]
        [InlineData("Hannah")]
        [InlineData("A man, a plan, a canal - Panama!")]
        [InlineData("Madam, I'm Adam")]
        [InlineData("Never odd or even")]
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
