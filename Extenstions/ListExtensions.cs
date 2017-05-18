using System;
using System.Collections.Generic;

namespace Extenstions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            var rnd = new Random();
            while (n > 1)
            {
                var k = (rnd.Next(0, n) % n);
                n--;
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
