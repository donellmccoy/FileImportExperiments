using FileImportExperiments.Models;

namespace FileImportExperiments.Services.Interfaces;

public interface ICacheService
{
    Task<IReadOnlyList<County>> GetCountiesAsync(CancellationToken token = default);
}