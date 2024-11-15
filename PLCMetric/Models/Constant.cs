namespace PLCMetric.Models
{
    public static class Constant
    {
        public const string Drirectory = "C:\\PLCLog\\";

        public static string HouseBomFilePath()
        {
            return $"{Drirectory}{DateTime.Now.ToString("yyyyMMdd")}_housebom_logs.json";
        }

        public static string JobBomFilePath()
        {
            return $"{Drirectory}{DateTime.Now.ToString("yyyyMMdd")}_jobbom_logs.json";
        }
    }
}
