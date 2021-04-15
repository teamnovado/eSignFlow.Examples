using ConsoleApp.Models;
using ConsoleApp.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    class CreateDocumentWithAttachments : TestBase
    {
        protected override async Task ExecuteInternal()
        {
            //Generate some PDF's and upload them
            //This will return a fileId (of type Guid)

            Guid fileId;
            using (var pdf = await Pdf.Generate("<h1>This PDF was generated in test<br/><em>CreateDocumentWithAttachments</em></h1>"))
            {
                fileId = await UploadPdf.Execute(Http, pdf, "TestFile.pdf");
            }
            Logger.WriteLine("Uploaded TestFile.pdf. Returned fileId = {0:D}", fileId);

            Guid attachId1;
            using (var pdf = await Pdf.Generate("<h1>This PDF (attachment 1) was generated in test<br/><em>CreateDocumentWithAttachments</em></h1>"))
            {
                attachId1 = await UploadPdf.Execute(Http, pdf, "Attachment1.pdf");
            }
            Logger.WriteLine("Uploaded Attachment1.pdf. Returned fileId = {0:D}", fileId);

            Guid attachId2;
            using (var pdf = await Pdf.Generate("<h1>This PDF (attachment 2) was generated in test<br/><em>CreateDocumentWithAttachments</em></h1>"))
            {
                attachId2 = await UploadPdf.Execute(Http, pdf, "Attachment2.pdf");
            }
            Logger.WriteLine("Uploaded Attachment2.pdf. Returned fileId = {0:D}", fileId);

            Guid attachId3;
            using (var pdf = await Pdf.Generate("<h1>This PDF (attachment 3) was generated in test<br/><em>CreateDocumentWithAttachments</em></h1>"))
            {
                attachId3 = await UploadPdf.Execute(Http, pdf, "Attachment3.pdf");
            }
            Logger.WriteLine("Uploaded Attachment3.pdf. Returned fileId = {0:D}", fileId);

            Guid attachId4;
            using (var pdf = await Pdf.Generate("<h1>This PDF (attachment 4) was generated in test<br/><em>CreateDocumentWithAttachments</em></h1>"))
            {
                attachId4 = await UploadPdf.Execute(Http, pdf, "Attachment4.pdf");
            }
            Logger.WriteLine("Uploaded Attachment4.pdf. Returned fileId = {0:D}", fileId);

            Logger.WriteLine();

            //Create a CreateDocumentsRequest and post it to eSignFlow
            //This returns a CreateDocumentsResponse

            int.TryParse(ConfigurationManager.AppSettings["SignerUserId.1"], out int signerUserId);
            int.TryParse(ConfigurationManager.AppSettings["ClusterId"], out int clusterId);
            int.TryParse(ConfigurationManager.AppSettings["TemplateId"], out int templateId);

            var signers = new[]
            {
                new DocumentSigner(signerUserId)
            };
            var attachments = new[]
            {
                new DocumentAttachment
                {
                    FileId = attachId1,
                    Title = "Att 1 (no signers)",
                    DocumentType = DocumentType.Attachment,
                    AttachmentSignersMode = AttachmentSignersMode.NoSigners
                },
                new DocumentAttachment
                {
                    FileId = attachId2,
                    Title = "Att (predefined signers)",
                    DocumentType = DocumentType.Attachment,
                    AttachmentSignersMode = AttachmentSignersMode.SignerPredefined,
                    Signers = signers
                },
                new DocumentAttachment
                {
                    FileId = attachId3,
                    Title = "Att 3 (inherited signers)",
                    DocumentType = DocumentType.Attachment,
                    AttachmentSignersMode = AttachmentSignersMode.SignersMainDocument
                },
                new DocumentAttachment
                {
                    FileId = attachId4,
                    Title = "Att 4 (creator)",
                    DocumentType = DocumentType.Attachment,
                    AttachmentSignersMode = AttachmentSignersMode.Creator //creator = user linked to ApiIdentityNrn
                }
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
                        InternalNote = "a note for the signers within the organisation",
                        ExternalNote = "a note for the receivers of this document",
                        Signers = signers,
                        Attachments = attachments
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