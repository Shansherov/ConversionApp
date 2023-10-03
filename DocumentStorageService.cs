using ConversionApp.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moravia.Homework.Interfaces;
using shared.auxilliary;

namespace Moravia.Homework
{
    /// <summary>
    /// Example of service to manage file conversion
    /// </summary>
    public class DocumentStorageService : IDocumentStorageService
    {
        private IStorage? _inputStorage;
        private IStorage? _outputStorage;
        private IDocumentFormat? _inputFormat;
        private IDocumentFormat? _outputFormat;
        private ILogger<DocumentService> _loggerDocumentService;
        private ILogger<DocumentStorageService> _logger;
        private DocumentService? _documentService;
        private IConfiguration _config;

        public DocumentStorageService(ILogger<DocumentService> loggerDocumentService, ILogger<DocumentStorageService> logger, IConfiguration config)
        {
            _loggerDocumentService = loggerDocumentService;
            _logger = logger;
            _config = config;

            ConversionSettings? conversionSettings = ConfigUtils.GetAppData<ConversionSettings>(_config, "ConversionSettings");

            if (conversionSettings != null)
            {
                switch (conversionSettings.InputFormat)
                {
                    case "XML":
                        _inputFormat = new XMLFormat();
                        break;
                    case "YAML":
                        _inputFormat = new YAMLFormat();
                        break;
                    default:
                        _inputFormat = new JSONFormat();
                        break;
                }

                switch (conversionSettings.OutputFormat)
                {
                    case "XML":
                        _outputFormat = new XMLFormat();
                        break;
                    case "YAML":
                        _outputFormat = new YAMLFormat();
                        break;
                    default:
                        _outputFormat = new JSONFormat();
                        break;
                }

                switch (conversionSettings.InputStorage)
                {
                    case "FileStorage":
                        _inputStorage = new FileStorage();
                        break;
                    case "CloudStorage":
                        _inputStorage = new FileStorage();
                        break;
                    default:
                        _inputStorage = new FileStorage();
                        break;
                }
                switch (conversionSettings.OuputStorage)
                {
                    case "FileStorage":
                        _outputStorage = new FileStorage();
                        break;
                    case "CloudStorage":
                        _outputStorage = new FileStorage();
                        break;
                    default:
                        _outputStorage = new FileStorage();
                        break;
                }

                _documentService = new DocumentService(_inputStorage, _outputStorage, _inputFormat, _outputFormat, _loggerDocumentService);

                _documentService.ConvertAndSaveDocument(conversionSettings.SourceFileName, conversionSettings.TargetFileName);
            }
        }
    }
}