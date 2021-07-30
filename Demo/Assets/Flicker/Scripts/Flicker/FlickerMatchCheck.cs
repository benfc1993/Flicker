using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Flicker
{
    internal static class FlickerCheck
    {
        public static T GetBestMatch<T>(List<T> flickList, FlickData flickData) where T : Flick
        {
            string pattern = flickData.Pattern;
            string shortCode = flickData.ShortCode;
            var matches = new List<T>();

            float codeAccuracy = 0.66f;
            float codeScore = shortCode.Length * codeAccuracy;
            float patternAccuracy = 0.75f;
            float patternScore = 0;
            T bestMatch = default(T);

            foreach (T flick in flickList)
            {
                if (StringComparison(flick.flickDataSO.shortCode, shortCode, ref codeScore, codeAccuracy))
                {
                    matches.Add(flick);
                }
            }

            foreach (T match in matches)
            {
                if (StringComparison(match.flickDataSO.pattern, pattern, ref patternScore, patternAccuracy))
                    bestMatch = match;
            }

            return bestMatch;

        }
        static bool StringComparison(string a, string b, ref float highScore, float accuracy)
        {
            string best = null;
            int score = 0;

            for (int i = 0; i < b.Length; i++)
            {
                if (a.Length > i && a[i] == b[i])
                    score++;
            }

            if (score > highScore && score >= (a.Length * accuracy))
            {
                highScore = score;
                best = a;
            }

            return best != null;
        }
    }
}
