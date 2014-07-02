using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienRegistrationCoreLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FileWritingPlugInAttribute : Attribute
    {
        public FileWritingPlugInAttribute(string description)
        {
            f_Description = description;
        }

        private string f_Description;

        public string Description
        {
            get { return f_Description; }
            set { f_Description = value; }
        }
    }
}
