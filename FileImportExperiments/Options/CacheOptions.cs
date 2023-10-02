namespace FileImportExperiments.Options;

public class CacheOptions
{
    public TimeSpan AbsoluteExpirationRelativeToNow
    {
        get;
        set;
    }

    public TimeSpan AbsoluteExpiration
    {
        get;
        set;
    }
}