using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    class GetDocumentSignersList : TestBase
    {
        protected override async Task ExecuteInternal()
        {
            var response = await Requests.GetDocumentSignersList.Execute(Http);

            Logger.WriteLine("GetDocumentSignersList response:");
            Logger.WriteLine(Serialize(response));
            Logger.WriteLine();
        }
    }
}