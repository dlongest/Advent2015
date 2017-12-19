using Advent2015.Core.Problem5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem5
{
    public class NiceStringRuleTests
    {
        [Theory]
        [InlineData("aei", true)]
        [InlineData("aeiouaeiouaeious", true)]
        [InlineData("aaa", true)]
        [InlineData("aab", false)]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void ThreeNiceVowels_CorrectlyValidates(string s, bool expected)
        {
            var sut = new ThreeVowelsNiceStringRule();

            Assert.Equal(expected, sut.IsNice(s));
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("aaa", true)]      
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("dvszwmarrgswjxmb", true)]
        public void DoubleLetter_CorrectlyValidates(string s, bool expected)
        {
            var sut = new DoubleLetterNiceStringRule();

            Assert.Equal(expected, sut.IsNice(s));
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("jchzalrnumimnmhp", true)]
        [InlineData("ab", false)]
        [InlineData("cd", false)]
        [InlineData("pq", false)]
        [InlineData("xy", false)]
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", true)]
        public void InvalidSubstringNiceStringRule_CorrectlyValidates(string s, bool expected)
        {
            var sut = new InvalidSubstringNiceStringRule();

            Assert.Equal(expected, sut.IsNice(s));
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("jchzalrnumimnmhp", false)]      
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void Composite_AppliesAllRules_ToDetermineNiceness(string s, bool expected)
        {
            var sut = new CompositeNiceStringRule(new ThreeVowelsNiceStringRule(),
                                                    new DoubleLetterNiceStringRule(),
                                                    new InvalidSubstringNiceStringRule());

            Assert.Equal(expected, sut.IsNice(s));
        }

        [Theory]
        [InlineData("xyxy", true)]
        [InlineData("aabcdefgaa", true)]
        [InlineData("aaa", false)]
        [InlineData("qjhvhtzxzqqjkmpb", true)]
        [InlineData("xxyxx", true)]
        [InlineData("uurcxstgmygtbstg", true)]
        [InlineData("ieodomkazucvgmuy", false)]   
        public void MultiplyAppearingPair_CorrectlyValidates(string s, bool expected)
        {
            var sut = new MultiplyAppearingPairNiceStringRule();

            Assert.Equal(expected, sut.IsNice(s));
        }

        [Theory]
        [InlineData("xyxy", true)]
        [InlineData("aabcdefgaa", false)]
        [InlineData("aaa", true)]
        [InlineData("qjhvhtzxzqqjkmpb", true)]
        [InlineData("xxyxx", true)]
        [InlineData("uurcxstgmygtbstg", false)]
        [InlineData("ieodomkazucvgmuy", true)]
        [InlineData("abcdefeghi", true)]
        public void RepeatingLetterWithSeparator_CorrectlyValidates(string s, bool expected)
        {
            var sut = new RepeatingLetterWithSeparatorNiceStringRule();

            Assert.Equal(expected, sut.IsNice(s));
        }
    }
}
