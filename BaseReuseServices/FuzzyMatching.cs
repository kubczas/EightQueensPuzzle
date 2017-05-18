using System;

namespace BaseReuseServices
{
    //Jaro Winkler alghoritm
    public class FuzzyMatching : IFuzzyMatching
    {
        private const double WeightThreshold = 0.7;
        private static readonly int NumChars = 4;

        public double Distance(string string1, string string2)
        {
            return 1.0 - Proximity(string1, string2);
        }

        public double Proximity(string string1, string string2)
        {
            var len1 = string1.Length;
            var len2 = string2.Length;
            if (len1 == 0)
                return len2 == 0 ? 1.0 : 0.0;

            var searchRange = Math.Max(0, Math.Max(len1, len2) / 2 - 1);

            // default initialized to false
            var matched1 = new bool[len1];
            var matched2 = new bool[len2];

            var numCommon = 0;
            for (var i = 0; i < len1; ++i)
            {
                var start = Math.Max(0, i - searchRange);
                var end = Math.Min(i + searchRange + 1, len2);
                for (var j = start; j < end; ++j)
                {
                    if (matched2[j]) continue;
                    if (string1[i] != string2[j])
                        continue;
                    matched1[i] = true;
                    matched2[j] = true;
                    ++numCommon;
                    break;
                }
            }
            if (numCommon == 0) return 0.0;

            var numHalfTransposed = 0;
            var k = 0;
            for (var i = 0; i < len1; ++i)
            {
                if (!matched1[i]) continue;
                while (!matched2[k]) ++k;
                if (string1[i] != string2[k])
                    ++numHalfTransposed;
                ++k;
            }
            var numTransposed = numHalfTransposed / 2;

            double numCommonD = numCommon;
            var weight = (numCommonD / len1
                             + numCommonD / len2
                             + (numCommon - numTransposed) / numCommonD) / 3.0;

            if (weight <= WeightThreshold)
                return weight;
            var lMax = Math.Min(NumChars, Math.Min(string1.Length, string2.Length));
            var lPos = 0;
            while (lPos < lMax && string1[lPos] == string2[lPos])
                ++lPos;
            if (lPos == 0) return weight;
            return weight + 0.1 * lPos * (1.0 - weight);
        }
    }
}
