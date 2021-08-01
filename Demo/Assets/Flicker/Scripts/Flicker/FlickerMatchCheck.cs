using System.Collections.Generic;
using UnityEngine;

namespace Flicker
{
    internal static class FlickerCheck
    {
        public static T GetBestMatch<T>(List<T> flickList, FlickData flickData, float shortCodeAccuracy = 0.66f, float patternAccuracy = 0.75f ) where T : Flick
        {
            string pattern = flickData.Pattern;
            string shortCode = flickData.ShortCode;
            var matches = new List<T>();

            float codeScore = shortCode.Length * shortCodeAccuracy;
            float patternScore = float.PositiveInfinity;
            T bestMatch = default(T);

            foreach (T flick in flickList)
            {
                if (StringComparison(flick.flickDataSO.shortCode, shortCode, ref codeScore, shortCodeAccuracy, true))
                {
                    matches.Add(flick);
                }
            }

            foreach (T match in matches)
            {
                if (NumberComparison(match.flickDataSO.pattern, pattern, ref patternScore, patternAccuracy))
                    bestMatch = match;
            }

            return bestMatch;

        }

        static bool NumberComparison(string a, string b, ref float highScore, float accuracy)
        {
            string aNumbers = a.Replace("SW", "").Replace("SC", "").Replace("FF", "");
            string bNumbers = b.Replace("SW", "").Replace("SC", "").Replace("FF", "");
            string best = null;
            int score = 0;

            for (int i = 0; i < bNumbers.Length; i++)
            {
                if (aNumbers.Length > i)
                    score +=  Mathf.Abs(aNumbers[i] - bNumbers[i]);
            }

            if (bNumbers[0] >= (aNumbers[0] - 1) && bNumbers[0] <= (aNumbers[0] + 1) && bNumbers[1] >= (aNumbers[1] - 1) && bNumbers[1] <= (aNumbers[1] + 1) &&
                bNumbers[bNumbers.Length - 1] >= (aNumbers[aNumbers.Length - 1] - 1) && bNumbers[bNumbers.Length - 1] <= (aNumbers[aNumbers.Length - 1] + 1) &&
                bNumbers[bNumbers.Length - 2] >= (aNumbers[aNumbers.Length - 2] - 1) && bNumbers[bNumbers.Length - 2] <= (aNumbers[aNumbers.Length - 2] + 1))
            {
                if (score < highScore && score <= (a.Length * accuracy))
                {
                    highScore = score;
                    best = a;
                }
            }

            return best != null;
        }

        static bool StringComparison(string a, string b, ref float highScore, float accuracy, bool canHaveEquals = false )
        {
            string best = null;
            int score = 0;

            for (int i = 0; i < b.Length; i++)
            {
                if (a.Length > i && a[i] == b[i])
                    score++;
            }

            if ((canHaveEquals ? score >= highScore : score > highScore) && score >= (a.Length * accuracy))
            {
                highScore = score;
                best = a;
            }

            return best != null;
        }


    }
}
