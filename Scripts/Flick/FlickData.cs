public struct FlickData
{
    public string ShortCode { get; private set; }
    public string Pattern { get; private set; }

    public FlickData(string shortCode, string pattern)
    {
        Pattern = pattern;
        ShortCode = shortCode;
    }
}
