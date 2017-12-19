using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem4
{
    public interface IAdventCoinValidator
    {
        bool IsValid(string hexadecimalHash);
    }

}
