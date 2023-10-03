using Moravia.Homework.Interfaces;
using Newtonsoft.Json;
using System.Xml;
using YamlDotNet.Serialization;

namespace Moravia.Homework
{
    /// <summary>
    /// YAML Format Implementation
    /// </summary>
    public class YAMLFormat : IDocumentFormat
    {
        public string ConvertFromJson(string content)
        {
            // Serialize object to YAML
            var serializer = new SerializerBuilder().JsonCompatible().Build();
            var yamlContent = serializer.Serialize(content);

            return yamlContent;
        }

        public string ConvertToJson(string content)
        {
            // Deserialize YAML to object
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(new StringReader(content));

            // Serialize object to JSON
            var jsonString = JsonConvert.SerializeObject(yamlObject, Newtonsoft.Json.Formatting.Indented);
            return jsonString;
        }
    }
}

