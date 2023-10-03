using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Moravia.Homework.Interfaces
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
