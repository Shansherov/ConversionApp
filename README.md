# Document Conversion System

The **Document Conversion System** is a versatile tool designed to handle various document formats, including XML, JSON, and YAML. It provides seamless conversion between these formats and supports flexible storage options, such as local file storage and cloud storage solutions.

## Features

- **Multi-Format Support**: Convert documents between XML, JSON, and YAML formats effortlessly.
- **Dynamic XML Parsing**: Handle XML data with varying element names by dynamically extracting all descendant elements and converting them into a dictionary.
- **Flexible Storage Options**: Store documents locally or in the cloud, giving you the freedom to choose the most suitable storage solution for your needs.
- **Customizable Configurations**: Configure input and output formats, storage types, and other settings through an intuitive configuration system.
- **Easy Integration**: Seamlessly integrate the Document Conversion System into your applications using the provided interfaces and services.

## Installation

To install the Document Conversion System, follow these steps:

1. **Clone the Repository**: `git clone <repository-url>`
2. **Navigate to the Project Directory**: `cd document-conversion-system`
3. **Build the Project**: `dotnet build`
4. **Run the Application**: `dotnet run`

## Usage

### Adding new format

The application uses the approach with the converting the given input format to `JSON` format. For the implementetion of the new format create new class using `IDocumentFormat` interface.
And then integrate `ConvertFromJson` and `ConvertToJson` methods.

See the example:

```csharp
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
```


### Configuring Input and Output Formats

You can configure input and output formats, as well as storage options, using the `appsettings.json` file. Here's an example configuration:

jsonCopy code

`{
  "ConversionSettings": {
    "InputFormat": "JSON",
    "OutputFormat": "XML",
    "InputStorage": "FileStorage",
    "OutputStorage": "FileStorage",
    "SourceFileName": "SourceFiles\\Document1.json",
    "TargetFileName": "TargetFiles\\Document1.xml"
  }
`

Thank you for using the Document Conversion System! If you have any questions or issues, please don't hesitate to [reach out](mailto:shansherov@gmail.com). Happy coding!