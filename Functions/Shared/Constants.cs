namespace OSSGolfLeagueManager.Functions.Shared
{
    public class Constants
    {
        private EnvironmentVariableNames _envVarNames;
        private GoogleSheetPlayerColumnIndexes _playerIndexes;
        public EnvironmentVariableNames EnvironmentVariableNames => _envVarNames;
        public GoogleSheetPlayerColumnIndexes GoogleSheetPlayerColumnIndexes => _playerIndexes;
        public Constants(EnvironmentVariableNames envVarNames,
                         GoogleSheetPlayerColumnIndexes playerIndexes)
        {
            _envVarNames = envVarNames;
            _playerIndexes = playerIndexes;
        }

    }

    public class EnvironmentVariableNames
    {
        public string ApiKey => "sheetsApiKey";
        public string PlayerRange => "playerRange";
        public string SheetId => "sheetId";
    }

    public class GoogleSheetPlayerColumnIndexes
    {
        public int ID => 0;
        public int FirstName => 1;
        public int LastName => 2;
        public int PreferredName => 3;
        public int Email => 4;
        public int Phone => 5;
        public int PlayerOrSub => 6;
    }
}