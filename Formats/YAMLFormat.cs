using ConversionApp.Interfaces;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace ConversionApp
{
    /// <summary>
    /// YAML Format Implementation
    /// </summary>
    public class YAMLFormat : IDocumentFormat
    {
        /// <summary>
        /// Convert string context to YAML format
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ConvertFromJson(string content)
        {
            try
            {
                // Serialize object to YAML
                var serializer = new SerializerBuilder().JsonCompatible().Build();
                var yamlContent = serializer.Serialize(content);

                return yamlContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion from JSON to YAML failed with exception message: {ex.Message}");
                throw;
            }
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
                // Deserialize YAML to object
                var deserializer = new DeserializerBuilder().Build();
                var yamlObject = deserializer.Deserialize(new StringReader(content));

                // Serialize object to JSON
                var jsonString = JsonConvert.SerializeObject(yamlObject, Newtonsoft.Json.Formatting.Indented);
                return jsonString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion from YAML to JSON failed with exception message: {ex.Message}");
                throw;
            }
        }
    }
}

