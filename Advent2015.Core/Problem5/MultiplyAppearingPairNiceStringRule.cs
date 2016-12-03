using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class MultiplyAppearingPairNiceStringRule : RegexNiceStringRule
    {       
        public MultiplyAppearingPairNiceStringRule()
            :base(@"([a-z]{2}).*\1")
        {
        }
    }
}
