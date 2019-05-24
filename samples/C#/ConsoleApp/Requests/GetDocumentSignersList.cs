using ConsoleApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.Tests;

namespace ConsoleApp.Requests
{
    class GetDocumentSignersList
    {
        public static async Task<DocumentSignersResponse> Execute(HttpClient http)
        {
            var responseMessage = await http.GetAsync("documentsigners/list");

            if (!responseMessage.IsSuccessStatusCode)
                throw await ApiException.Create(responseMessage);

            return await responseMessage.Content.ReadAsAsync<DocumentSignersResponse>();
        }
    }
}