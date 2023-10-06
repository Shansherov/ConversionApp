using ConversionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionApp
{
    /// <summary>
    /// File System Storage Implementation
    /// </summary>
    public class FileStorage : IStorage
    {
        /// <summary>
        /// Read the string context from the file with given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public string Read(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllText(path);
                }
                else
                {
                    throw new FileNotFoundException("File not found.", path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Reading from file has been failed with exception message: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Write the string context to the file with given path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Write(string path, string content)
        {
            try
            {
                // Ensure the directory exists, if not, create it
                var directory = Path.GetDirectoryName(path);

                if (directory == null) throw new ArgumentNullException($"The given path: {path} for target file does not exist");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write content to the file
                File.WriteAllText(path, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Writing to file has been failed with exception message: {ex.Message}");
                throw;
            }
        }
    }
}
