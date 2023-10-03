using Moravia.Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moravia.Homework
{
    public class CloudStorage : IStorage
    {
        private Dictionary<string, string> cloudStorage = new Dictionary<string, string>();

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

        public void Write(string path, string content)
        {
            cloudStorage[path] = content;
        }
    }
}
