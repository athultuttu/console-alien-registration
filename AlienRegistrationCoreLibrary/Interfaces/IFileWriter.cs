using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienRegistrationCoreLibrary.Interfaces
{
    public interface IFileWriter
    {
        void FileWrite(string message);

        string GetDescription();
    }
}
