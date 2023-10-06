using ConversionApp.Interfaces;
using Newtonsoft.Json;

namespace ConversionApp
{
    /// <summary>
    /// JSON Format Implementation
    /// </summary>
    public class JSONFormat : IDocumentFormat
    {
        /// <summary>
        /// Convert string context from JSON format 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ConvertFromJson(string content)
        {
            // No need to serialize the json string
            return content;
        }
        /// <summary>
        /// Convert string context to JSON format
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ConvertToJson(string content)
        {
            try
            {
                var jsonData = JsonConvert.DeserializeObject(content);

                if (jsonData != null) return jsonData.ToString();
                else return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion to JSON failed with exception message: {ex.Message}");
                throw;
            }
        }
    }
}
