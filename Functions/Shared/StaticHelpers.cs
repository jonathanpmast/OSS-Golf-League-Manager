
namespace OSSGolfLeagueManager.Functions.Shared
{
    public static class StaticHelpers
    {
        public static string GetEnvironmentVariable(string name) =>
            System.Environment.GetEnvironmentVariable(name, System.EnvironmentVariableTarget.Process);
    }
}