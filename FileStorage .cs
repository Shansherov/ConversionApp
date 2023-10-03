using Moravia.Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moravia.Homework
{
    /// <summary>
    /// File System Storage Implementation
    /// </summary>
    public class FileStorage : IStorage
    {
        public string Read(string path)
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

        public void Write(string path, string content)
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
    }
}
