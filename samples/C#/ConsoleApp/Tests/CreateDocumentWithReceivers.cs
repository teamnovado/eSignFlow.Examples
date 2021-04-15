using ConsoleApp.Models;
using ConsoleApp.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    class CreateDocumentWithReceivers : TestBase
    {
        protected override async Task ExecuteInternal()
        {
            //Generate some PDF's and upload them
            //This will return a fileId (of type Guid)

            Guid fileId;
            using (var pdf = await Pdf.Generate("<h1>This PDF was generated in test<br/><em>CreateDocumentWithReceivers</em></h1>"))
            {
                fileId = await UploadPdf.Execute(Http, pdf, "TestFile.pdf");
            }
            Logger.WriteLine("Uploaded TestFile.pdf. Returned fileId = {0:D}", fileId);
            Logger.WriteLine();

            //Create a CreateDocumentsRequest and post it to eSignFlow
            //This returns a CreateDocumentsResponse

            int.TryParse(ConfigurationManager.AppSettings["SignerUserId.1"], out int signerUserId1);
            int.TryParse(ConfigurationManager.AppSettings["ClusterId"], out int clusterId);
            int.TryParse(ConfigurationManager.AppSettings["TemplateId"], out int templateId);

            var signers = new[]
            {
                new DocumentSigner(signerUserId1)
            };
            var receivers = new[]
            {
                new DocumentReceiver { Email = "eSignFlow.document.receiver.1@mailinator.com" },
                new DocumentReceiver { Email = "eSignFlow.document.receiver.2@mailinator.com" }
            };
            var request = new CreateDocumentsRequest
            {
                Documents = new List<Document>
                {
                    new Document
                    {
                        FileId = fileId,
                        Title = $"Testdocument {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                        OrganisationClusterId = clusterId,
                        TemplateId = templateId,
                        DocumentType = DocumentType.Default,
                        LanguageId = 1,
                        Signers = signers,
                        Receivers = receivers
                    }
                }
            };
            var created = await CreateDocument.Execute(Http, request);

            Logger.WriteLine("CreateDocument response:");
            Logger.WriteLine(Serialize(created));
            Logger.WriteLine();
        }
    }
}