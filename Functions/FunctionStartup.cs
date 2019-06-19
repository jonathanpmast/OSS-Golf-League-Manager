using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OSSGolfLeagueManager.Functions.Shared;

[assembly: FunctionsStartup(typeof(OSSGolfLeagueManager.Functions.Startup))]


namespace OSSGolfLeagueManager.Functions {
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddLogging();
            builder.Services.AddSingleton<Constants>();
            builder.Services.AddSingleton<EnvironmentVariableNames>();
            builder.Services.AddSingleton<GoogleSheetPlayerColumnIndexes>();
            builder.Services.AddTransient<GoogleSheetProvider>();
        }
    }
}