using AlienRegistrationCoreLibrary.Attributes;
using AlienRegistrationCoreLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TextWriter
{
    [FileWritingPlugInAttribute("This Plugin writes a text file")]
    public class TextWriter : IFileWriter
    {
        public void FileWrite(string message)
        {
            string fileName = "C:/files/AlienEntry.txt";
            StreamWriter sw;
            sw = File.CreateText(fileName);
            sw.WriteLine(message);
            Process.Start(fileName);
            sw.Close();
        }
        public string GetDescription()
        {
            return "Text";
        }                
    }
}
