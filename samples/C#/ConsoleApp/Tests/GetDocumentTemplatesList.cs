using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    class GetDocumentTemplatesList : TestBase
    {
        protected override async Task ExecuteInternal()
        {
            var response = await Requests.GetDocumentTemplatesList.Execute(Http, 10, 0, false);

            Logger.WriteLine("GetDocumentTemplatesList response:");
            Logger.WriteLine(Serialize(response));
            Logger.WriteLine();
        }
    }
}