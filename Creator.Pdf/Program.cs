using System;
using MigraDoc.DocumentObjectModel.Tables;

namespace Creator.Pdf
{
    using PdfSharp;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;

    public class Program
    {
        static void Main()
        {
            // Triabva da se obsudi kak shte se formatira zashtoto niama opcii za vkarvane na tablici
            // i podobni neshta v pdfsharp, a niamame nikakvo vreme do predavaneto. predlagam da se
            // formatirat kato string i posle da se izpechatat na ekrana v pdf-a

            PdfFileStructure content = new PdfFileStructure();
            content.filename = "employee-sallaries";
            content.title = "Report: Employees sallaries";
            content.separatorHeading = "September";
            content.data = new string[]
            {
                "Name: Vesela Pavlova Ivancheva            Sallary: 1000 levs",
                "Name: Minka Kovacheva Jeliazkova            Sallary: 800 levs",
                "Name: Reneta Raikova Todorova            Sallary: 900 levs"
            };
            content.total = 2700;
            
            CreatePdf(content);
        }

        public struct PdfFileStructure
        {
            public string filename;
            public string title;
            public string separatorHeading;
            public string[] data;
            public int total;
        }

        public static void CreatePdf(PdfFileStructure _content)
        {
            //TODO: Generate file and requirements
            PdfDocument pdfDocument = new PdfDocument();
            PdfPage pdfPage = pdfDocument.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            //TODO: Set font
            XFont font = new XFont("Tahoma", 18, XFontStyle.Bold);

            //TODO: Input title
            int startX = 0;
            int startY = 0;
            graph.DrawString(_content.title,
                font,
                XBrushes.Black,
                new XRect(startY, startX, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.TopCenter
                );

            //TODO: Draw line separator
            XPen pen = new XPen(XColors.RoyalBlue);
            graph.DrawLine(pen, 75, 50, 525, 50);

            //TODO: Draw heading
            font = new XFont("Tahoma", 12, XFontStyle.Bold);
            graph.DrawString(_content.separatorHeading,
                font,
                XBrushes.Black,
                new XRect(75, 34, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.TopLeft
                );

            //TODO: Draw data rows
            font = new XFont("Tahoma", 12, XFontStyle.Bold);
            int rowOffset = 39;
            for (int i = 0; i < _content.data.Length; i++)
            {
                rowOffset += 25;
                graph.DrawString(_content.data[i],
                font,
                XBrushes.Black,
                new XRect(75, rowOffset, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.TopLeft
                );
            }

            //TODO: Draw line separator
            pen = new XPen(XColors.RoyalBlue);
            graph.DrawLine(pen, 75, rowOffset + 30, 525, rowOffset + 30);

            //TODO: Draw total
            graph.DrawString("Total: " + _content.total.ToString(),
                font,
                XBrushes.Black,
                new XRect(startY + 70, rowOffset + 40, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.TopCenter
                );

            //TODO: Save PDF Document
            pdfDocument.Save(_content.filename + ".pdf");
        }
    }
}
