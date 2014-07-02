using AlienRegistrationCoreLibrary.Attributes;
using AlienRegistrationCoreLibrary.Interfaces;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PdfWriter
{
    [FileWritingPlugInAttribute("This Plugin will write a Pdf file")]
    public class PdfWriter : IFileWriter
    {
        public void FileWrite(string message)
        {
            PdfDocument myDoc = new PdfDocument();
            PdfPage myPage = myDoc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(myPage);
            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect rect = new XRect(40, 100, 500, 500);
            gfx.DrawRectangle(XBrushes.Transparent, rect);
            tf.DrawString(message, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            string filename = String.Format("AlienEntry.pdf");
            myDoc.Save(filename);
            Process.Start(filename);
        }
        public string GetDescription()
        {
            return "Pdf";
        }
    }
}
