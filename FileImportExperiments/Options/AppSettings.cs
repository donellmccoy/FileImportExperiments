namespace FileImportExperiments.Options;

public class AppSettings
{
    public string ImportFolderPath
    {
        get;
        set;
    }

    public DatabaseOptions DatabaseOptions
    {
        get;
        set;
    }

    public CacheOptions CacheOptions
    {
        get;
        set;
    }
}