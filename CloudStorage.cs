using ConversionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionApp
{
    /// <summary>
    /// Example of Cloud Storage with dictionary interpretation
    /// </summary>
    public class CloudStorage : IStorage
    {
        private Dictionary<string, string> cloudStorage = new Dictionary<string, string>();

        /// <summary>
        /// Read data from cloud storage
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public string Read(string path)
        {
            if (cloudStorage.ContainsKey(path))
            {
                return cloudStorage[path];
            }
            else
            {
                throw new KeyNotFoundException("File not found in cloud storage.");
            }
        }

        /// <summary>
        /// Write data to cloud storage
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public void Write(string path, string content)
        {
            cloudStorage[path] = content;
        }
    }
}
