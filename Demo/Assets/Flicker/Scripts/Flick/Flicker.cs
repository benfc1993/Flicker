using System.Collections.Generic;

static class FlickerCheck
{
    public static T GetBestMatch<T>(List<T> flickList, FlickData flickData) where T : FlickASO
    {
        string pattern = flickData.Pattern;
        string shortCode = flickData.ShortCode;
        var matches = new List<T>();

        int highScore = 0;
        T bestMatch = default(T);

        foreach (T flick in flickList)
        {
            if (flick.shortCode == shortCode )
            {
                matches.Add(flick);
            }
        }

        foreach (T match in matches)
        {
            int score = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (match.pattern[i] == pattern[i])
                {
                    score++;
                }
            }
            if (score > highScore && score > (match.pattern.Length * 0.75))
            {
                highScore = score;
                bestMatch = match;
            }
        }


        return bestMatch;
    }
}
