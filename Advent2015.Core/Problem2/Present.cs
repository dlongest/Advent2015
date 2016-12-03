using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2015.Core.Problem2
{
    public class Present
    {
        public Present(string dimensions)
        {
            var d = dimensions.Split(new char[] { 'x' });

            this.Length = Int32.Parse(d[0]);
            this.Width = Int32.Parse(d[1]);
            this.Height = Int32.Parse(d[2]);
        }

        public int Length { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int WrappingPaperAreaNeeded()
        {
            return SurfaceArea() + SmallestSideArea();
        }

        public int RibbonNeeded()
        {
            var sides = OrderedSides();

            var perimeter = sides[0] * 2 + sides[1] * 2;

            var bow = this.Length * this.Width * this.Height;

            return perimeter + bow;
        }

        private int SurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        private int SmallestSideArea()
        {
            var sides = OrderedSides();

            return sides[0] * sides[1];
        }   
        
        private int[] OrderedSides()
        {
            return new[] { this.Length, this.Width, this.Height }.OrderBy(a => a).ToArray();
        }    
    }

    public static class PresentExtensions
    {
        public static int TotalWrappingPaperNeeded(this IEnumerable<Present> presents)
        {
            return presents.Sum(p => p.WrappingPaperAreaNeeded());
        }

        public static int TotalRibbonNeeded(this IEnumerable<Present> presents)
        {
            return presents.Sum(p => p.RibbonNeeded());
        }
    }
}
