using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace Moravia.Homework
{
    public class Document
    {
        public string? Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "SourceFiles\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "TargetFiles\\Document1.json");

            string input = String.Empty;
            try
            {
                if (File.Exists(sourceFileName))
                {
                    using (FileStream sourceStream = File.Open(sourceFileName, FileMode.Open))
                    using (var reader = new StreamReader(sourceStream))
                        input = reader.ReadToEnd();
                }
                else
                {
                    Console.WriteLine("No source file has been found!");
                    return;
                }

                var xdoc = XDocument.Parse(input);
                var doc = new Document();

                if (xdoc.Root != null)
                {
                    if (xdoc.Root.Element("title") != null)
                    {
                        doc.Title = xdoc.Root.Element("title").Value;
                    }

                    if (xdoc.Root.Element("text") != null)
                    {
                        doc.Text = xdoc.Root.Element("text").Value;
                    }
                }
                var serializedDoc = JsonConvert.SerializeObject(doc);

                FileStream? targetStream;
                if (File.Exists(targetFileName))
                {
                    using (targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))

                    using (var sw = new StreamWriter(targetStream))
                    {
                        sw.Write(serializedDoc);
                    }
                }
                else
                {
                    Console.WriteLine($"No target file has been found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main method has been failed with error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}