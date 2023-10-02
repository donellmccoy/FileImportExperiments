using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;
using FileImportExperiments.Constants;
using FileImportExperiments.Extensions;
using FileImportExperiments.Models;
using FileImportExperiments.Options;
using FileImportExperiments.Services.Interfaces;
using FileImportExperiments.Strategies.Interfaces;
using Microsoft.Extensions.Options;

namespace FileImportExperiments.Strategies;

public class CriticalAndSuspectImportStrategy : ICriticalAndSuspectImportStrategy
{
    #region Fields

    private readonly ICacheService _cacheService;
    private readonly IFileService _fileService;
    private readonly IDataService _dataService;
    private readonly IOptions<AppSettings> _options;
    private readonly Regex _startOfPageRegex;
    private readonly Regex _startNewCaptureFromLineRegex;
    private readonly Regex _endOfReportRegex;
    private readonly Regex _pageHeaderRegex;
    private readonly Regex _dataExtractionRegex;

    #endregion

    #region Constructors

    public CriticalAndSuspectImportStrategy(ICacheService cacheService, 
        IFileService fileService, 
        IDataService dataService, 
        IOptions<AppSettings> options)
    {
        _cacheService = cacheService;
        _fileService = fileService;
        _dataService = dataService;
        _options = options;

        _startOfPageRegex = new Regex(RegularExpressions.StartOfPage);
        _startNewCaptureFromLineRegex = new Regex(RegularExpressions.StartNewCaptureFromLine);
        _endOfReportRegex = new Regex(RegularExpressions.EndOfReport);
        _pageHeaderRegex = new Regex(RegularExpressions.PageHeader);
        _dataExtractionRegex = new Regex(RegularExpressions.DataExtraction);
    }

    #endregion

    #region Methods

    public async System.Threading.Tasks.Task ExecuteAsync()
    {
        foreach (var county in await GetSortedCountiesAsync())
        {
            var countyId = county.CountyId;

            foreach (var filePath in GetSortedFilePaths(county.CountyCode))
            {
                var fileName = filePath.Replace(_options.Value.ImportFolderPath, string.Empty);
                var lines = await _fileService.GetTextLinesAsync(filePath);
                var lineItems = new List<LineItem>();
                var blobData = new StringBuilder();

                foreach (var line in lines)
                {
                    if (_endOfReportRegex.IsMatch(line))
                    {
                        break;
                    }

                    if (_startOfPageRegex.IsMatch(line))
                    {

                    }

                    if (_pageHeaderRegex.IsMatch(line))
                    {

                    }

                    if (_dataExtractionRegex.IsMatch(line) is false)
                    {
                        continue;
                    }

                    var data = _dataExtractionRegex.Match(line);

                    lineItems.Add(new LineItem
                    {
                        DateOfFile = data.Groups[nameof(LineItem.DateOfFile)].Value.Trim(),
                        ClerkNumber = data.Groups[nameof(LineItem.ClerkNumber)].Value.Trim().Replace("-", string.Empty),
                        TypeOfInstrument = data.Groups["TOI"].Value.Trim(),
                        Legal = data.Groups[nameof(LineItem.Legal)].Value.Trim(),
                        EventType = "C&S"
                    });

                    blobData.Append(line);
                    blobData.AppendLine(Environment.NewLine);
                }
            }
        }
    }

    private async Task<IReadOnlyList<County>> GetSortedCountiesAsync()
    {
        return (await _cacheService.GetCountiesAsync())
            .Where(county => county.IsActive is true)
            .OrderBy(county => county.CountyCode)
            .ToList();
    }

    private IEnumerable<string> GetSortedFilePaths(string countyCode)
    {
        return Directory
            .GetFiles(_options.Value.ImportFolderPath, $"CSCOMB-CNTY{countyCode[1..]}*.txt")
            .OrderBy(fullFilePath => fullFilePath.Replace(_options.Value.ImportFolderPath, string.Empty))
            .ToList();
    }

    private static async System.Threading.Tasks.Task ProcessText(string[] lines)
    {
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            //extract required information
        }

        await System.Threading.Tasks.Task.CompletedTask;
    }

    #endregion
}

//public override void Input0_ProcessInputRow(Input0Buffer Row)
// {
// filesPickedUp.Clear();
// filter = string.Format(inputFileFilter, Row.COUNTYCODE.Substring(1, Row.COUNTYCODE.Length - 1));
// filesPickedUp.AddRange(Directory.GetFiles(inputFilePath, filter));
// countyID = Row.COUNTYID;
// CreateNewOutputRows();
// }
// 
// public override void CreateNewOutputRows()
// {
// foreach (string file in filesPickedUp)
// {
// FilesFoundBuffer.AddRow();
// FilesFoundBuffer.CountyID = countyID;
// FilesFoundBuffer.FileName = file.Replace(inputFilePath, string.Empty);
// FilesFoundBuffer.FullFileName = file;
// }
// }
// public override void PostExecute()
// {
// base.PostExecute();
// Variables.DateString = DateTime.Now.ToString("yyyyMMdd_hhmmss");
// }

