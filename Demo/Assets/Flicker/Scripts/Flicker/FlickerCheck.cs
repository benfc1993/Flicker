using System.Collections.Generic;

namespace Flicker
{
    internal static class FlickerCheck
    {
        public static T GetBestMatch<T>(List<T> flickList, FlickDataStruct flickData) where T : Flick
        {
            string pattern = flickData.Pattern;
            string shortCode = flickData.ShortCode;
            var matches = new List<T>();

            int highScore = 0;
            T bestMatch = default(T);

            foreach (T flick in flickList)
            {
                if (flick.flickData.shortCode == shortCode )
                {
                    matches.Add(flick);
                }
            }

            foreach (T match in matches)
            {
                int score = 0;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (match.flickData.pattern[i] == pattern[i])
                    {
                        score++;
                    }
                }
                if (score > highScore && score > (match.flickData.pattern.Length * 0.75))
                {
                    highScore = score;
                    bestMatch = match;
                }
            }

            return bestMatch;
        }
    }
}
