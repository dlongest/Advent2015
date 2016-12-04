using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem6
{
    public class InstructionReader
    {
        public IEnumerable<Instruction> FromFile(string file)
        {
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    yield return Instruction.Create(reader.ReadLine());
                }
            }
        }
    }   
}
