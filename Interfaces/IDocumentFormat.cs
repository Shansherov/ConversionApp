namespace ConversionApp.Interfaces
{
    /// <summary>
    /// Interface for different document formats
    /// </summary>
    public interface IDocumentFormat
    {
        string ConvertFromJson(string content);
        string ConvertToJson(string content);
    }
}
