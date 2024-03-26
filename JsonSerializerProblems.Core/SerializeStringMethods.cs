using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace JsonSerializerProblems.Core
{
    public static class SerializeStringMethods
    {
        public static T? DeserializeWithNewtonSoft<T>(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return default;
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
        }

        public static T? DeserializeWithSystemTextJson<T>(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return default;
            }

            text = text.Replace("\r", "\\r");
            
            return JsonSerializer.Deserialize<T>(text/*, options*/);
        }
    }
}
