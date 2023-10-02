namespace FileImportExperiments.Constants;

public static class RegularExpressions
{
    public static string StartOfPage = @"(?<StartOfPage>(\d{2}\/\d{2}\/\d{4}\s+\d{2}:\d{2}:\d{2}\s+\*{4}\s+ATTORNEYS'\s+TITLE\s+FUND\s+SERVICES,\s+LLC.\s+\*{4}\s+PAGE\s+\d+))";
    public static string PageHeader = "(?<PageHeader>(.*COUNTY-.*$))";
    public static string DataExtraction = @"(SEC-)(?<ClerkNumber>\w*\d*-\d*)(\s|-)(\s*)(DOF-)(?<DateOfFile>\d\d/\d\d/\d\d\d\d)(.*)$|(SEC-)(?<ClerkNumber>\w*\d*-\d*)(\s|-)(.*)$|(DOF-)(?<DateOfFile>\d\d/\d\d/\d\d\d\d)(.*)$|(0\s*|0\s*\**)(TOI-\s)(?<TOI>\w{1,4})(.*$)|(0\s*)(LEGAL-\s)(?<Legal>.*$)";
    
    public static string StartNewCaptureFromLine = @"(?<StartNewCapture>(\-*\s$))";

    public static string EndOfReport = @"(?<EndOfReport>(\*\s+E\s+N\s+D\s+O\s+F\s+R\s+E\s+P\s+O\s+R\s+T\s+DATE\s+\d{2}\/\d{2}\/\d{4}\s+TIME\s+\d{2}:\d{2}:\d{2}\s+\*))";
}