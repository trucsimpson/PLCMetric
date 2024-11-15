using System.Text.Json;
using System.Text.Json.Serialization;

namespace PLCMetric.Models
{
    public class DoubleToStringConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (double.TryParse(reader.GetString(), out double result))
                        return result;
                    return 0;

                case JsonTokenType.Number:
                    return reader.GetDouble();

                default:
                    return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("F2"));
        }
    }
}
