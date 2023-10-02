using FileImportExperiments.Constants;
using FileImportExperiments.Models;
using FileImportExperiments.Options;
using FileImportExperiments.Services;
using FileImportExperiments.Services.Interfaces;
using FileImportExperiments.Strategies;
using FileImportExperiments.Strategies.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task = System.Threading.Tasks.Task;

namespace FileImportExperiments;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
                        .ConfigureAppConfiguration(builder =>
                        {
                            builder.SetBasePath(Directory.GetCurrentDirectory());
                            builder.AddJsonFile("appsettings.json", false, true);
                        })
                        .ConfigureServices((context, services) =>
                        {
                            services.AddMemoryCache();
                            services.AddSingleton<ICriticalAndSuspectImportStrategy, CriticalAndSuspectImportStrategy>();
                            services.AddSingleton<IMissingClerkNumberImportStrategy, MissingClerkNumberImportStrategy>();
                            services.AddSingleton<ICacheService, CacheService>();
                            services.AddSingleton<IDataService, DataService>();
                            services.AddSingleton<IFileService, FileService>();
                            services.Configure<AppSettings>(context.Configuration);
                            services.AddDbContextFactory<ApplicationDbContext>(optionsBuilder =>
                            {
                                optionsBuilder.EnableDetailedErrors();
                                optionsBuilder.UseSqlServer("Data Source=DESKTOP-91FGOH1;Initial Catalog=REAL_TIME_POSTING;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=True", builder =>
                                {
                                    builder.EnableRetryOnFailure(3);
                                });
                            });

                        })
                        .Build();

        var strategy = host.Services.GetService<ICriticalAndSuspectImportStrategy>();

        await strategy.ExecuteAsync();

        Console.ReadLine();
    }
}