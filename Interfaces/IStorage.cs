namespace ConversionApp.Interfaces
{
    /// <summary>
    /// Interface for different storage types
    /// </summary>
    public interface IStorage
    {
        string Read(string path);
        void Write(string path, string content);
    }
}
