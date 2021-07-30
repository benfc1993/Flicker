namespace Flicker
{
    public readonly struct FlickData
    {
        public string ShortCode { get; }
        public string Pattern { get; }

        public FlickData(string shortCode, string pattern)
        {
            ShortCode = shortCode;
            Pattern = pattern;
        }

    }
}
