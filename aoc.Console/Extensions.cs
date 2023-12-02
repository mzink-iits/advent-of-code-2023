using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Console
{
    public static class Extensions
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string searchString)
        {
            int minIndex = str.IndexOf(searchString);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchString, minIndex + searchString.Length);
            }
        }
    }
}
