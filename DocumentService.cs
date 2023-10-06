using Microsoft.Extensions.Logging;
using ConversionApp.Interfaces;

namespace ConversionApp
{
    /// <summary>
    /// DocumentService with Input/Output Storages and Formats
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly IStorage _inputStorage;
        private readonly IStorage _outputStorage;
        private readonly IDocumentFormat _inputFormat;
        private readonly IDocumentFormat _outputFormat;
        private readonly ILogger _logger;
        private readonly string _inputPath;
        private readonly string _outputPath;

        public DocumentService(
            IStorage inputStorage,
            IStorage outputStorage,
            IDocumentFormat inputFormat,
            IDocumentFormat outputFormat,
            string inputPath,
            string outputPath,
            ILogger logger
            )
        {
            _inputStorage = inputStorage;
            _outputStorage = outputStorage;
            _inputFormat = inputFormat;
            _outputFormat = outputFormat;
            _inputPath = inputPath;
            _outputPath = outputPath;
            _logger = logger;
        }

        /// <summary>
        /// Convert and save document based on the storage type and format
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        public void ConvertAndSaveDocument()
        {
            try
            {
                _logger.LogInformation($"Converting document from {_inputFormat.GetType().Name} to {_outputFormat.GetType().Name}");

                // Read content from input storage
                string inputContent = _inputStorage.Read(_inputPath);

                // Deserialize content to dynamic data (JSON or XML)
                dynamic documentData = _inputFormat.ConvertToJson(inputContent);

                // Serialize dynamic data back to the desired format
                string outputContent = _outputFormat.ConvertFromJson(documentData);

                // Write content to output storage
                _outputStorage.Write(_outputPath, outputContent);

                _logger.LogInformation($"Converting document has been successfully done!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method [ConvertAndSaveDocument] has been failed with the exception message: {ex.Message}");
                throw;
            }
        }
    }
}
