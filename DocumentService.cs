using Microsoft.Extensions.Logging;
using Moravia.Homework.Interfaces;

namespace Moravia.Homework
{
    /// <summary>
    /// DocumentService with Input/Output Storages and Format
    /// </summary>
    public class DocumentService
    {
        private readonly IStorage _inputStorage;
        private readonly IStorage _outputStorage;
        private readonly IDocumentFormat _inputFormat;
        private readonly IDocumentFormat _outputFormat;
        private readonly ILogger <DocumentService> _logger;

        public DocumentService(
            IStorage inputStorage, 
            IStorage outputStorage,
            IDocumentFormat inputFormat, 
            IDocumentFormat outputFormat, 
            ILogger<DocumentService> logger
            )
        {
            _inputStorage = inputStorage;
            _outputStorage = outputStorage;
            _inputFormat = inputFormat;
            _outputFormat = outputFormat;
            _logger = logger;
        }

        public void ConvertAndSaveDocument(string inputPath, string outputPath)
        {
            _logger.LogInformation($"Converting document from {_inputFormat.GetType().Name} to {_outputFormat.GetType().Name}");

            try
            {
                // Read content from input storage
                string inputContent = _inputStorage.Read(inputPath);

                // Deserialize content to dynamic data (JSON or XML)
                dynamic documentData = _inputFormat.ConvertToJson(inputContent);

                // Serialize dynamic data back to the desired format
                string outputContent = _outputFormat.ConvertFromJson(documentData);

                // Write content to output storage
                _outputStorage.Write(outputPath, outputContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
