using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JsonSerializerProblems.Core.Model
{
    public class MyModel
    {
        [JsonProperty("payload")]
        [JsonPropertyName("payload")]
        public  string? Payload { get; set; }
    }
}
