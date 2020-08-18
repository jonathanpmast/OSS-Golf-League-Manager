using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using OSSGolfLeagueManager.Functions.Shared;

namespace Functions
{
    public class GoogleSheetImportFunctions
    {
        private Constants _constants;
        private GoogleSheetProvider _provider;

        public GoogleSheetImportFunctions(Constants constants, GoogleSheetProvider provider) {
            _constants = constants;
            _provider = provider;
        }

        [FunctionName("GoogleSheetPlayerImport")]
        public async Task PlayerImport([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var data = await _provider.GetPlayers();
        }
    }
}
