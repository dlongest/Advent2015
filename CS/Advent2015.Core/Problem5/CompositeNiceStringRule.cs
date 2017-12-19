using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem5
{
    public class CompositeNiceStringRule : INiceStringRule
    {
        private INiceStringRule[] rules;

        public CompositeNiceStringRule(params INiceStringRule[] rules)
        {
            this.rules = rules;
        }

        public CompositeNiceStringRule()
            :this(new ThreeVowelsNiceStringRule(), 
                 new DoubleLetterNiceStringRule(), 
                 new InvalidSubstringNiceStringRule())
        {
        }

        public bool IsNice(string s)
        {
            return this.rules.All(a => a.IsNice(s));
        }
    }
}
