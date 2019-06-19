using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using OSSGolfLeagueManager.Functions.Shared;

namespace OSSGolfLeagueManager.Functions
{
    public class PlayerApi
    {
        private Constants _constants;
        private GoogleSheetProvider _googleSheetProvider;

        public PlayerApi(Constants constants, GoogleSheetProvider googleSheetProvider) {
            _constants = constants;
            _googleSheetProvider = googleSheetProvider;
        }

        [FunctionName("GetPlayers")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "players")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var players = await _googleSheetProvider.GetPlayers();
            return (ActionResult)new OkObjectResult(JsonConvert.SerializeObject(players));
        }


    }
}
