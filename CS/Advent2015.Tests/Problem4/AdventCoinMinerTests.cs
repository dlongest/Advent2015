using Advent2015.Core.Problem4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent2015.Tests.Problem4
{
    public class AdventCoinMinerTests
    {        
        // Test runs but is too time-consuming to run regularly.  Uncomment the [Theory] if you want to run it.
        //[Theory]
        [InlineData("abcdef", "00000", 609043)]
        [InlineData("pqrstuv", "00000", 1048970)]
        [InlineData("ckczppom", "00000", 117946)]
        [InlineData("ckczppom", "000000", 3938038)]
        public void AdventCoinMiner_FindsCorrectNumber_ForSecretKey(string secretKey, string prefix, int expected)
        {
            var miner = new AdventCoinMiner(new AdventCoinPrefixValidator(prefix));

            var number = miner.Mine(secretKey);

            Assert.Equal(expected, number);
        }
    }
}
