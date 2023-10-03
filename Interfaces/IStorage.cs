using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moravia.Homework.Interfaces
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
