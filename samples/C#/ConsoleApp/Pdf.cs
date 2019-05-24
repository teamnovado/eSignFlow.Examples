using IronPdf;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Pdf
    {
        public static async Task<Stream> Generate(string html = null)
        {
            var options = new PdfPrintOptions
            {
                PaperSize = PdfPrintOptions.PdfPaperSize.A4,
                PaperOrientation = PdfPrintOptions.PdfPaperOrientation.Portrait
            };

            var renderer = new HtmlToPdf(options);
            var pdf = await renderer.RenderHtmlAsPdfAsync(html ?? "<h1>This is an auto generated PDF document.</h1>");

            return pdf.Stream;
        }
    }
}