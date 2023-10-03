using Moravia.Homework.Interfaces;
using Newtonsoft.Json;

namespace Moravia.Homework
{
    /// <summary>
    /// JSON Format Implementation
    /// </summary>
    public class JSONFormat : IDocumentFormat
    {
        public string ConvertFromJson(string content)
        {
            // No need to serialize the json string
            return content;
        }
        public string ConvertToJson(string content)
        {
            var jsonData = JsonConvert.DeserializeObject(content);

            if (jsonData != null) return jsonData.ToString();
            else return string.Empty;
        }
    }
}
