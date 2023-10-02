using FileImportExperiments.Services.Interfaces;

namespace FileImportExperiments.Services;

public class FileService : IFileService
{
    public async Task<string[]> GetTextLinesAsync(string filePath, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));
        }

        if (File.Exists(filePath) is false)
        {
            throw new FileNotFoundException("File not found", filePath);
        }

        return await File.ReadAllLinesAsync(filePath, token);
    }
}