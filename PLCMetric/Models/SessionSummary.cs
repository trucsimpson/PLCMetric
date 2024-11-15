using System.Text.Json.Serialization;

namespace PLCMetric.Models
{
    public class SessionSummary
    {
        [JsonPropertyName("totalExecutionTimeMs")]
        public double TotalExecutionTimeMs { get; set; }

        [JsonPropertyName("totalMemoryUsageMB")]
        public double TotalMemoryUsageMB { get; set; }

        [JsonPropertyName("slowestOperation")]
        public OperationSummary SlowestOperation { get; set; }

        [JsonPropertyName("highestMemoryOperation")]
        public OperationSummary HighestMemoryOperation { get; set; }
    }

    public class OperationSummary
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("executionTimeMs")]
        public double ExecutionTimeMs { get; set; }

        [JsonPropertyName("memoryUsageMB")]
        public double MemoryUsageMB { get; set; }
    }

    public class PerformanceMetric : OperationSummary
    {
        [JsonPropertyName("children")]
        public List<PerformanceMetric> Children { get; set; }

        public PerformanceMetric()
        {
            Children = new List<PerformanceMetric>();
        }
    }
}
