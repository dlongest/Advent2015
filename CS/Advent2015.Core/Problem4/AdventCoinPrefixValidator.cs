using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem4
{
    public class AdventCoinPrefixValidator : IAdventCoinValidator
    {
        private string prefix;

        public AdventCoinPrefixValidator(string requiredPrefix)
        {
            this.prefix = requiredPrefix;
        }

        public bool IsValid(string hexadecimalHash)
        {
            return hexadecimalHash.StartsWith(this.prefix);
        }
    }
}
