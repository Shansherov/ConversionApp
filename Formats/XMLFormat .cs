using Moravia.Homework.Interfaces;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace Moravia.Homework
{
    /// <summary>
    /// XML Format Implementation
    /// </summary>
    public class XMLFormat : IDocumentFormat
    {
        public string ConvertFromJson(string content)
        {
            XNode? node = JsonConvert.DeserializeXNode(content, "Root");

            if (node != null) return node.ToString();
            else return string.Empty;
        }

        public string ConvertToJson(string content)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);
            string jsonData = JsonConvert.SerializeXmlNode(xmlDocument);

            return jsonData;
        }
    }
}

