using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class RegexNiceStringRule : INiceStringRule
    {
        private readonly Regex niceRegex;

        public RegexNiceStringRule(string niceRegexPattern)
        {
            this.niceRegex = new Regex(niceRegexPattern);
        }

        public bool IsNice(string s)
        {
            return this.niceRegex.IsMatch(s);
        }
    }
}
