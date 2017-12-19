using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class RepeatingLetterWithSeparatorNiceStringRule : RegexNiceStringRule
    {
        public RepeatingLetterWithSeparatorNiceStringRule()
            :base(@"([a-z]).\1")
        {
        }
    }
}
