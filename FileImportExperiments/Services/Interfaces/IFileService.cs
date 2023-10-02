namespace FileImportExperiments.Services.Interfaces;

public interface IFileService
{
    Task<string[]> GetTextLinesAsync(string filePath, CancellationToken token = default);
}