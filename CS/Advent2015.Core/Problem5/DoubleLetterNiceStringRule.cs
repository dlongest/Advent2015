using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class DoubleLetterNiceStringRule : INiceStringRule
    {
        private string[] doubles = new string[]
        {
            "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm",
            "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
        };

        public bool IsNice(string s)
        {
            return this.doubles.Select(d => s.Contains(d))
                        .Any(a => a == true);
        }
    }
}
