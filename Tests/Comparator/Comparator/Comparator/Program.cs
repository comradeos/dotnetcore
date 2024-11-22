using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace Comparator;

public static class Program
{
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        
        Console.WriteLine("Hello, World!");
        
        const string file1 = "SampleDoc1.docx";
        const string file2 = "SampleDoc2.rtf";
        const string file3 = "SampleDoc3.pdf";

        Console.WriteLine(File.Exists(file1) ? "SampleDoc1.docx exists" : "File1 does not exist");
        Console.WriteLine(File.Exists(file2) ? "SampleDoc2.rtf exists" : "File2 does not exist");
        Console.WriteLine(File.Exists(file3) ? "SampleDoc3.pdf exists" : "File3 does not exist");
        
        ParseDocx(file1);
        
        ParseRtf(file2);
        
        ParsePdf(file3);
    }
    
    private static void ParseDocx(string file)
    {
        string filePath = file;

        try
        {
            using WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false);

            Body? body = wordDoc.MainDocumentPart.Document.Body;

            foreach (var paragraph in body.Elements<Paragraph>())
            {
                string text = paragraph.InnerText;

                if (!string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine(text);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка ParseDocx: {ex.Message}");
        }
    }
    
    private static void ParseRtf(string filePath)
    {
        try
        {
            // Читаем содержимое RTF-файла как строку
            string rtfContent = File.ReadAllText(filePath);

            // Преобразуем RTF в обычный текст
            string plainText = RtfPipe.Rtf.ToHtml(rtfContent);

            Console.WriteLine("Содержимое RTF-документа:");
            Console.WriteLine(plainText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка ParseRtf: {ex.Message}");
        }
    }
    
    private static void ParsePdf(string filePath)
    {
        try
        {
            using PdfReader pdfReader = new PdfReader(filePath);
            using PdfDocument pdfDoc = new PdfDocument(pdfReader);
            
            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                Console.WriteLine($"Страница {i}:\n{pageText}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка ParsePdf: {ex.Message}");
        }
    }
    
    
    
    

}

