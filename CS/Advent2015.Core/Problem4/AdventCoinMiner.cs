using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem4
{
    public class AdventCoinMiner
    {
        private IAdventCoinValidator validator;

        public AdventCoinMiner(IAdventCoinValidator validator)
        {
            this.validator = validator;
        }

        public int Mine(string secretKey)
        {
            foreach (var number in GenerateNumbers())
            {
                var hash = ComputeHexadecimalhash(secretKey, number);

                if (this.validator.IsValid(hash))
                    return number;
            }

            throw new ArgumentException("Wasn't able to find a number that yields a valid coin with this key");
        }   
        
        private IEnumerable<int> GenerateNumbers()
        {
            int i = 0;
            while (true)
            {
                yield return i++;
            }
        }  

        private string ComputeHexadecimalhash(string secretKey, int decimalNumber)
        {
            using (var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                var input = string.Format("{0}{1}", secretKey, decimalNumber);

                var bytes = System.Text.Encoding.Default.GetBytes(input);

                var outputBytes = md5.ComputeHash(bytes);

                return outputBytes.ToHexString();
            }
        }
    }    
   

    public static class StringExtensions
    {
        public static string ToHexString(this byte[] bytes)
        {
            var hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }
    }
}
