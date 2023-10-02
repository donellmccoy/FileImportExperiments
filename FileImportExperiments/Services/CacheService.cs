using FileImportExperiments.Models;
using FileImportExperiments.Options;
using FileImportExperiments.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FileImportExperiments.Services;

public class CacheService : ICacheService
{
    #region Fields

    private readonly IMemoryCache _cache;
    private readonly IDataService _dataService;
    private readonly ILogger<CacheService> _logger;
    private readonly CacheOptions _cacheOptions;

    #endregion

    #region Constructors

    public CacheService(IMemoryCache cache, IDataService dataService, IOptions<AppSettings> options, ILogger<CacheService> logger)
    {
        _cache = cache;
        _dataService = dataService;
        _logger = logger;
        _cacheOptions = options.Value.CacheOptions;
    }

    #endregion

    #region Methods

    public async Task<IReadOnlyList<County>> GetCountiesAsync(CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(CacheKeys.Counties, entry =>
        {
            entry.SetAbsoluteExpiration(_cacheOptions.AbsoluteExpiration);
            return _dataService.GetCountiesAsync(token);
        });
    }

    #endregion

    #region Classes

    private static class CacheKeys
    {
        public const string Counties = $"_{nameof(Counties)}";
    }

    #endregion
}
