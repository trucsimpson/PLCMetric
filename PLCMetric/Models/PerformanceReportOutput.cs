using System.Text.Json.Serialization;

namespace PLCMetric.Models
{
    public class PerformanceReportOutput
    {
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }

        [JsonPropertyName("startRunTime")]
        public string StartRunTime { get; set; }

        [JsonPropertyName("isGlobalOption")]
        public bool IsGlobalOption { get; set; }

        [JsonPropertyName("summary")]
        public SessionSummary Summary { get; set; }

        [JsonPropertyName("metrics")]
        public List<PerformanceMetric> Metrics { get; set; }

        [JsonPropertyName("detailedMetrics")]
        public List<DetailedMetrics> DetailedMetrics { get; set; }

        public PerformanceReportOutput()
        {
            Metrics = new List<PerformanceMetric>();
            Summary = new SessionSummary();
            DetailedMetrics = new List<DetailedMetrics>();
        }
    }
}
