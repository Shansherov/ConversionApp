using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionApp.Configuration
{
    public class ConversionSettings
    {
        public string InputFormat { get; set; } = string.Empty;
        public string OutputFormat { get; set; } = string.Empty;
        public string InputStorage { get; set; } = string.Empty;
        public string OuputStorage { get; set; } = string.Empty;
        public string SourceFileName { get; set; } = string.Empty;
        public string TargetFileName { get; set; } = string.Empty;
    }
}
