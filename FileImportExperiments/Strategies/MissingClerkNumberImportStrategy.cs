using FileImportExperiments.Options;
using FileImportExperiments.Services.Interfaces;
using FileImportExperiments.Strategies.Interfaces;
using Microsoft.Extensions.Options;

namespace FileImportExperiments.Strategies;

public class MissingClerkNumberImportStrategy : IMissingClerkNumberImportStrategy
{
    #region Fields

    private readonly ICacheService _cacheService;
    private readonly IFileService _fileService;
    private readonly IDataService _dataService;
    private readonly IOptions<AppSettings> _options;

    #endregion

    #region Constructors

    public MissingClerkNumberImportStrategy(ICacheService cacheService, 
        IFileService fileService, 
        IDataService dataService, 
        IOptions<AppSettings> options)
    {
        _cacheService = cacheService;
        _fileService = fileService;
        _dataService = dataService;
        _options = options;
    }

    #endregion

    #region Methods

    public async Task ExecuteAsync()
    {
        var counties = await _cacheService.GetCountiesAsync();


        foreach (var county in counties)
        {
            var lines = await _fileService.GetTextLinesAsync(CreateFilePath(county.CountyCode));

            if (lines.Any() is false)
            {
                continue;
            }

            await ProcessText(lines);
        }
    }

    private string CreateFilePath(string countyCode)
    {
        return $@"{_options.Value.ImportFolderPath}\MISSCN-CNTY{countyCode}-{1}*.txt";
    }

    private static async Task ProcessText(string[] lines)
    {
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            //extract required information
        }

        await Task.CompletedTask;
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


