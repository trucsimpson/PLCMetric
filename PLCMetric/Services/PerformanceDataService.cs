using PLCMetric.Models;
using System.Text.Json;

namespace PLCMetric.Services
{
    public interface IPerformanceDataService
    {
        Task<List<PerformanceReportOutput>> GetHouseBomMetricsAsync();
        Task<List<PerformanceReportOutput>> GetJobBomMetricsAsync();
    }

    public class PerformanceDataService : IPerformanceDataService
    {
        private readonly JsonSerializerOptions _jsonOptions;

        public PerformanceDataService()
        {
            _jsonOptions = new JsonSerializerOptions
            {
                Converters = { new DoubleToStringConverter() },
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<List<PerformanceReportOutput>> GetHouseBomMetricsAsync()
        {
            if (!File.Exists(Constant.HouseBomFilePath()))
                return new List<PerformanceReportOutput>();

            string jsonContent = await File.ReadAllTextAsync(Constant.HouseBomFilePath());
            var result = JsonSerializer.Deserialize<List<PerformanceReportOutput>>(jsonContent, _jsonOptions)
                   ?? new List<PerformanceReportOutput>();
            return result.OrderByDescending(t => DateTime.Parse(t.StartRunTime)).ToList();
        }

        public async Task<List<PerformanceReportOutput>> GetJobBomMetricsAsync()
        {
            if (!File.Exists(Constant.JobBomFilePath()))
                return new List<PerformanceReportOutput>();

            string jsonContent = await File.ReadAllTextAsync(Constant.JobBomFilePath());
            var result = JsonSerializer.Deserialize<List<PerformanceReportOutput>>(jsonContent, _jsonOptions)
                   ?? new List<PerformanceReportOutput>();
            return result.OrderByDescending(t => DateTime.Parse(t.StartRunTime)).ToList();
        }
    }
}
