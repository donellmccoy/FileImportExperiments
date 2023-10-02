using FileImportExperiments.Models;
using Task = FileImportExperiments.Models.Task;

namespace FileImportExperiments.Services.Interfaces;

public interface IDataService
{
    Task<List<County>> GetCountiesAsync(CancellationToken token = default);
    Task<Event> AddEvent(byte? countyId, long? dateOfFileId, string eventTypeCode, string reportFileName,
        CancellationToken token = default);
    Task<Task> AddTask(long taskId, string taskTypeCode, long eventId, bool? assigned,
        bool? complete,
        CancellationToken token = default);
    Task<TaskDetail> AddTaskDetail(long taskId, string secondaryReference, DateTime? deleteAfterDate,
        string typeOfInstrument,
        string legalDescription,
        CancellationToken token = default);
    Task<TaskDetailBlob> AddTaskDetailBlob(long taskDetailId, string taskDetail, CancellationToken token = default);
}