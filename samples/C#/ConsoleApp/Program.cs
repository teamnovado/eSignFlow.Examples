using ConsoleApp.Tests;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    ///
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            //Create a document based on a predefined template
            await new CreateDocumentWithTemplateAndGetStatus().Execute();

            //Create a document with attachments
            await new CreateDocumentWithAttachments().Execute();
            //Create a document with ordered signers
            await new CreateDocumentWithOrderedSigners().Execute();
            //Create a document with an external signer
            await new CreateDocumentWithExternalSigner().Execute();
            //Create a document with receivers
            await new CreateDocumentWithReceivers().Execute();
            //Create a draft document
            await new CreateDraftDocument().Execute();

            //This test fetches the list of possible signers: persons and groups
            await new GetDocumentSignersList().Execute();

            //This test fetches the list of documenttemplates
            await new GetDocumentTemplatesList().Execute();
        }
    }
}
