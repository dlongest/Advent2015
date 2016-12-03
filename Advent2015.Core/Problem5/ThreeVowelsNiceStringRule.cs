using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class ThreeVowelsNiceStringRule : INiceStringRule
    {
        private char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        public bool IsNice(string s)
        {
            return s.Where(c => IsVowel(c)).Count() >= 3;         
        }

        private bool IsVowel(char c)
        {
            return this.vowels.Contains(c);
        }
    }
}
