using ConsoleApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.Tests;

namespace ConsoleApp.Requests
{
    class GetStatus
    {
        public static async Task<DocumentStatusResponse> Execute(HttpClient http, int documentId)
        {
            var responseMessage = await http.GetAsync("Documents/Status?id=" + documentId);

            if (!responseMessage.IsSuccessStatusCode)
                throw await ApiException.Create(responseMessage);

            return await responseMessage.Content.ReadAsAsync<DocumentStatusResponse>();
        }
    }
}