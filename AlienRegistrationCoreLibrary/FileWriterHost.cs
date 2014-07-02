using AlienRegistrationCoreLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienRegistrationCoreLibrary
{
    public class FileWriterHost
    {
        public FileWriterHost(IFileWriter fileWriter)
        {
            fWriter = fileWriter;
        }

        
        private string fileString;
        private IFileWriter fWriter;

        public string X
        {
            get { return fileString; }
            set { fileString = value; }
        }        

        public void FileWrite()
        {
            fWriter.FileWrite(fileString);
        }

        public string GetDescription()
        {
            return fWriter.GetDescription();
        }

    }
}
