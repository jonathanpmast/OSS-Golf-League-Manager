using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using OSSGolfLeagueManager.Functions.Models;

namespace OSSGolfLeagueManager.Functions.Shared
{
    public class GoogleSheetProvider
    {
        private readonly Constants _constants;
        private ILogger _log;

        public GoogleSheetProvider(Constants constants, ILoggerFactory loggerFactory)
        {
            _constants = constants;
            _log = loggerFactory.CreateLogger<GoogleSheetProvider>();
        }

        public async Task<List<Player>> GetPlayers()
        {
            _log.LogInformation("]GetPlayers::Enter");
            List<Player> players = new List<Player>();
            SheetsService service = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = StaticHelpers.GetEnvironmentVariable(_constants.EnvironmentVariableNames.ApiKey)
            });
            var request = service.Spreadsheets.Values.Get(StaticHelpers.GetEnvironmentVariable(_constants.EnvironmentVariableNames.SheetId), StaticHelpers.GetEnvironmentVariable(_constants.EnvironmentVariableNames.PlayerRange));
            var response = await request.ExecuteAsync();
            for (int i = 1; i < response.Values.Count; i++)
            {

                _log.LogDebug($"Hydrating record {i} from SpreadSheet");
                var value = response.Values[i];
                if (value.Count > 1 && 
                    (!string.IsNullOrWhiteSpace(value[_constants.GoogleSheetPlayerColumnIndexes.FirstName]?.ToString() ?? string.Empty) ||
                     !string.IsNullOrWhiteSpace(value[_constants.GoogleSheetPlayerColumnIndexes.LastName]?.ToString() ?? string.Empty))
                )
                {
                    players.Add(
                       new Player()
                       {
                           Id = Convert.ToInt32(value[_constants.GoogleSheetPlayerColumnIndexes.ID] ?? -1),
                           FirstName = Convert.ToString(value[_constants.GoogleSheetPlayerColumnIndexes.FirstName] ?? string.Empty),
                           LastName = Convert.ToString(value[_constants.GoogleSheetPlayerColumnIndexes.LastName] ?? string.Empty),
                           Email = Convert.ToString(value[_constants.GoogleSheetPlayerColumnIndexes.Email] ?? string.Empty),
                           Phone = Convert.ToString(value[_constants.GoogleSheetPlayerColumnIndexes.Phone] ?? string.Empty),
                           PlayerOrSub = Enum.Parse<PlayerOrSub>(Convert.ToString(value[_constants.GoogleSheetPlayerColumnIndexes.PlayerOrSub])),
                           Preferred = Convert.ToString(value[_constants.GoogleSheetPlayerColumnIndexes.PreferredName] ?? string.Empty)
                       }
                   );
                }

            }
            _log.LogInformation("GetPlayers::Exit");
            return players;
        }
    }
}