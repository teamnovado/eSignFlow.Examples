using ConsoleApp.Models;
using ConsoleApp.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    class CreateDocumentWithTemplateAndGetStatus : TestBase
    {
        protected override async Task ExecuteInternal()
        {
            //Generate a PDF and upload it
            //This will return a fileId (of type Guid)

            Guid fileId;
            using (var pdf = await Pdf.Generate("<h1>This PDF was generated in test<br/><em>CreateDocumentWithTemplateAndGetStatus</em></h1>"))
            {
                fileId = await UploadPdf.Execute(Http, pdf, "TestFile.pdf");
            }

            Logger.WriteLine("Uploaded pdf. Returned fileId = {0:D}", fileId);
            Logger.WriteLine();

            //Create a CreateDocumentsRequest and post it to eSignFlow
            //This returns a CreateDocumentsResponse

            int.TryParse(ConfigurationManager.AppSettings["TemplateId"], out int templateId);

            var request = new CreateDocumentsRequest()
            {
                Documents = new List<Document>
                {
                    new Document
                    {
                        FileId = fileId,
                        Title = $"Testdocument {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                        TemplateId = templateId
                    }
                    //It is possible to send multiple documents at once
                }
            };
            var created = await CreateDocumentWithTemplate.Execute(Http, request);

            Logger.WriteLine("CreateDocument response:");
            Logger.WriteLine(Serialize(created));
            Logger.WriteLine();

            //Now check for the current status of the document

            var status = await GetStatus.Execute(Http, created.Documents.First().Id);

            Logger.WriteLine("GetStatus response:");
            Logger.WriteLine(Serialize(status));
            Logger.WriteLine();
        }
    }
}