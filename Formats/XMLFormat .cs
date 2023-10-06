using ConversionApp.Interfaces;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace ConversionApp
{
    /// <summary>
    /// XML Format Implementation
    /// </summary>
    public class XMLFormat : IDocumentFormat
    {
        /// <summary>
        /// Convert string context to XML format
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ConvertFromJson(string content)
        {
            try
            {
                XNode? node = JsonConvert.DeserializeXNode(content, "Root");

                if (node != null) return node.ToString();
                else return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion from JSON to XML failed with exception message: {ex.Message}");
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
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(content);
                string jsonData = JsonConvert.SerializeXmlNode(xmlDocument);

                return jsonData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion from XML to JSON failed with exception message: {ex.Message}");
                throw;
            }
        }
    }
}

