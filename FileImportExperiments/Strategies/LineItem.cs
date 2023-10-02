namespace FileImportExperiments.Strategies;

public record LineItem
{
    public string DateOfFile
    {
        get;
        set;
    }

    public string ClerkNumber
    {
        get;
        set;
    }

    public string TypeOfInstrument
    {
        get;
        set;
    }

    public string Legal
    {
        get;
        set;
    }

    public string EventType
    {
        get;
        set;
    }
}