namespace ConversionApp.Configuration
{
    /// <summary>
    /// This class sets the configuration settings
    /// </summary>
    public class ConversionSettings
    {
        public string InputFormat { get; set; } = string.Empty;
        public string OutputFormat { get; set; } = string.Empty;
        public string InputStorage { get; set; } = string.Empty;
        public string OutputStorage { get; set; } = string.Empty;
        public string SourceFileName { get; set; } = string.Empty;
        public string TargetFileName { get; set; } = string.Empty;
    }
}
