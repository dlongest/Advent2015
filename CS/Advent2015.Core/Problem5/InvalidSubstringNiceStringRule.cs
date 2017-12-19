using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class InvalidSubstringNiceStringRule : INiceStringRule
    {
       private string[] notAllowed = new string[]
       {
           "ab", "cd", "pq", "xy"
       };

        public bool IsNice(string s)
        {
            return notAllowed.Select(n => s.Contains(n)).All(a => a == false);
        }
    }
}
