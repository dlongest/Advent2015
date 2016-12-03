using Advent2015.Core.Problem1;
using Advent2015.Core.Problem2;
using Advent2015.Core.Problem3;
using Advent2015.Core.Problem4;
using Advent2015.Core.Problem5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Runner
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var reader = new StreamReader("P5.txt"))
            {
                var niceRule = new CompositeNiceStringRule(new MultiplyAppearingPairNiceStringRule(),
                                                            new RepeatingLetterWithSeparatorNiceStringRule());

                int nice = 0;

                while (!reader.EndOfStream)
                {
                    if (niceRule.IsNice(reader.ReadLine()))
                        nice++;
                }

                Console.WriteLine("Nice = {0}", nice);
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
