using System.Text.Json.Serialization;

namespace PLCMetric.Models
{
    public class DetailedMetrics
    {
        [JsonPropertyName("isGlobalOption")]
        public bool IsGlobalOption { get; set; }

        [JsonPropertyName("summary")]
        public SessionSummary Summary { get; set; }

        [JsonPropertyName("metrics")]
        public List<PerformanceMetric> Metrics { get; set; }

        public DetailedMetrics()
        {
            Metrics = new List<PerformanceMetric>();
            Summary = new SessionSummary();
        }
    }
}
