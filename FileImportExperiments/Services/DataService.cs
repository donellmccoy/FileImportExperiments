using FileImportExperiments.Models;
using FileImportExperiments.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = FileImportExperiments.Models.Task;

namespace FileImportExperiments.Services;

public class DataService : IDataService
{
    #region Fields

    private readonly IDbContextFactory<ApplicationDbContext> _factory;

    #endregion

    #region Constructors

    public DataService(IDbContextFactory<ApplicationDbContext> factory)
    {
        _factory = factory;
    }

    #endregion

    #region Methods

    //select * from (select * from [DCW].[EVENT]) [refTable]
    // where [refTable].[REPORT_FILE_NAME] = ?

    //User::CountyID,
    //User::EventTypeCode,
    //User::FileFullName,
    //User::FileNameToProcess,

    //User::PatternEndOfFile,
    //User::PatternPulData,
    //User::PatternStartIgnore,
    //User::PatternStartNewCaptureFromHeader,
    //User::PatternStartNewCaptureFromLine

    //select *
    //from
    //(SELECT DATE_OF_FILE_ID,
    //CONVERT(VARCHAR(10), COUNTY_ID) AS COUNTY_ID,
    //CONVERT(VARCHAR(10), [DATE], 101) AS DATE,
    //IS_CERTIFIED
    //FROM dbo.DATE_OF_FILE) [refTable]
    //where[refTable].[DATE] = ? and [refTable].[COUNTY_ID] = ?

    public async Task<List<County>> GetCountiesAsync(CancellationToken token = default)
    {
        await using var context = await _factory.CreateDbContextAsync(token);
        return await context.County.ToListAsync(cancellationToken: token);
    }

    public async Task<Event> AddEvent(byte? countyId, 
        long? dateOfFileId, 
        string eventTypeCode, 
        string reportFileName, 
        CancellationToken token = default)
    {
        await using var context = await _factory.CreateDbContextAsync(token);

        var entity = await context.Event.AddAsync(new Event
        {
            CountyId = countyId, 
            DateOfFileId = dateOfFileId, 
            EventTypeCode = eventTypeCode, 
            ReportFileName = reportFileName
        }, token);

        await context.SaveChangesAsync(token);

        return entity.Entity;
    }

    public async Task<Task> AddTask(long taskId, string taskTypeCode, 
        long eventId, 
        bool? assigned, 
        bool? complete, 
        CancellationToken token = default)
    {
        await using var context = await _factory.CreateDbContextAsync(token);

        var entity = await context.Task.AddAsync(new Task
        {
            TaskId = taskId, 
            TaskTypeCode = taskTypeCode, 
            EventId = eventId,
            Assigned = assigned,
            Complete = complete
        }, token);

        await context.SaveChangesAsync(token);

        return entity.Entity;
    }

    public async Task<TaskDetail> AddTaskDetail(long taskId, 
        string secondaryReference,
        DateTime? deleteAfterDate,
        string typeOfInstrument,
        string legalDescription,
        CancellationToken token = default)
    {
        await using var context = await _factory.CreateDbContextAsync(token);

        var entity = await context.TaskDetail.AddAsync(new TaskDetail
        {
            TaskId = taskId,
            SecondaryReference = secondaryReference,
            DeleteAfterDate = deleteAfterDate,
            TypeOfInstrument = typeOfInstrument,
            LegalDescription = legalDescription
        }, token);

        await context.SaveChangesAsync(token);

        return entity.Entity;
    }

    public async Task<TaskDetailBlob> AddTaskDetailBlob(long taskDetailId, string taskDetail, CancellationToken token = default)
    {
        await using var context = await _factory.CreateDbContextAsync(token);

        var entity = await context.TaskDetailBlob.AddAsync(new TaskDetailBlob
        {
            TaskDetailId = taskDetailId,
            TaskDetail = taskDetail

        }, token);

        await context.SaveChangesAsync(token);

        return entity.Entity;
    }

    #endregion
}

//[Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
// public class ScriptMain : UserComponent
// {
// private Regex StartIgnorePattern;
// private Regex StartNewCaptureFromLinePattern;
// private Regex EndOfFilePattern;
// private Regex StartNewCaptureFromHeaderPattern;
// private Regex PullDataPattern;
// private bool IgnoreLines = true;
// private bool CaptureData = false;
// private StringBuilder DetailData = new StringBuilder();
// private string EventTypeCode = string.Empty;
// private int DateOfFileID = 0;
// private string FileName = string.Empty;
// private DateTime DateOfFile = DateTime.MinValue;
// private string TypeOfInstrument = string.Empty;
// private string LegalDescription = string.Empty;
// private string ClerkNumber = string.Empty;
// private bool FirstTimeThrough = true;
// 
// public override void PreExecute()
// {
// base.PreExecute();
// StartIgnorePattern = new Regex(Variables.PatternStartIgnore);
// StartNewCaptureFromLinePattern = new Regex(Variables.PatternStartNewCaptureFromLine);
// EndOfFilePattern = new Regex(Variables.PatternEndOfFile);
// StartNewCaptureFromHeaderPattern = new Regex(Variables.PatternStartNewCaptureFromHeader);
// PullDataPattern = new Regex(Variables.PatternPulData);
// EventTypeCode = Variables.EventTypeCode;
// }
// 
// public override void PostExecute()
// {
// base.PostExecute();
// /*
// Add your code here for postprocessing or remove if not needed
// You can set read/write variables here, for example:
// Variables.MyIntVar = 100
// */
// }
// 
// public override void GSReportDetail_ProcessInputRow(GSReportDetailBuffer Row)
// {
// if (IgnoreLines)
// {
// Match newCapture = StartNewCaptureFromLinePattern.Match(Row.DetailReportLine);
// Match newHeaderCapture = StartNewCaptureFromHeaderPattern.Match(Row.DetailReportLine);
// if ((newCapture.Groups["StartNewCapture"].Success == true && newCapture.Groups["StartNewCapture"].Value.Trim() != string.Empty)
// || (newHeaderCapture.Groups["StartHeaderCapture"].Success == true && newHeaderCapture.Groups["StartHeaderCapture"].Value.Trim() != string.Empty))
// {
// CaptureData = true;
// IgnoreLines = false;
// FileName = Variables.FileNameToProcess;
// }
// }
// else if (CaptureData)
// {
// Match endOfReports = EndOfFilePattern.Match(Row.DetailReportLine);
// Match newIgnore = StartIgnorePattern.Match(Row.DetailReportLine);
// Match newCapture = StartNewCaptureFromLinePattern.Match(Row.DetailReportLine);
// if ((newIgnore.Groups["StartIgnore"].Success == true && newIgnore.Groups["StartIgnore"].Value.Trim() != string.Empty))
// {
// CaptureData = false;
// IgnoreLines = true;
// }
// else if ((newCapture.Groups["StartNewCapture"].Success == true && newCapture.Groups["StartNewCapture"].Value.Trim() != string.Empty)
// || (endOfReports.Groups["EndOfReport"].Success == true && endOfReports.Groups["EndOfReport"].Value.Trim() != string.Empty))
// {
// CreateNewOutputRows();
// 
// if (DetailData.Length > 0)
// {
// DetailData.Remove(0, DetailData.Length);
// }
// 
// DateOfFile = DateTime.MinValue;
// TypeOfInstrument = string.Empty;
// LegalDescription = String.Empty;
// }
// else
// {
// Match DataCapture = PullDataPattern.Match(Row.DetailReportLine);
// 
// if ((DataCapture.Groups["DateOfFile"].Success == true && DataCapture.Groups["DateOfFile"].Value.TrimEnd() != string.Empty))
// {
// DateOfFile = DateTime.Parse(DataCapture.Groups["DateOfFile"].Value.Trim());
// }
// if ((DataCapture.Groups["TOI"].Success == true && DataCapture.Groups["TOI"].Value.TrimEnd() != string.Empty))
// {
// TypeOfInstrument = DataCapture.Groups["TOI"].Value.Trim();
// }
// if ((DataCapture.Groups["Legal"].Success == true && DataCapture.Groups["Legal"].Value.TrimEnd() != string.Empty))
// {
// LegalDescription = DataCapture.Groups["Legal"].Value.Trim();
// }
// if ((DataCapture.Groups["ClerkNumber"].Success == true && DataCapture.Groups["ClerkNumber"].Value.TrimEnd() != string.Empty))
// {
// ClerkNumber = DataCapture.Groups["ClerkNumber"].Value.Trim().Replace("-", string.Empty);
// }
// 
// DetailData.Append(Row.DetailReportLine);
// DetailData.Append(Environment.NewLine);
// }
// }
// }
// 
// public override void CreateNewOutputRows()
// {
// if (FirstTimeThrough)
// {
// FirstTimeThrough = false;
// return;
// }
// 
// GSReportDataBuffer.AddRow();
// GSReportDataBuffer.DateOfFile = DateOfFile.ToString("MM/dd/yyyy");
// GSReportDataBuffer.EventTypeCode = EventTypeCode;
// GSReportDataBuffer.FileName = FileName.Substring(FileName.LastIndexOf('\\') + 1, FileName.Length - (FileName.LastIndexOf('\\') + 1));
// GSReportDataBuffer.TypeOfInstrument = TypeOfInstrument;
// GSReportDataBuffer.LegalDescription = LegalDescription;
// GSReportDataBuffer.CountyID = Variables.CountyID.ToString();
// GSReportDataBuffer.ClerkNumber = ClerkNumber;
// GSReportDataBuffer.DetailData.AddBlobData(System.Text.Encoding.UTF8.GetBytes(DetailData.ToString()));
// }
// }