using ConsoleApp.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.Tests;

namespace ConsoleApp.Requests
{
    class GetDocumentTemplatesList
    {
        public static async Task<DocumentTemplatesResponse> Execute(HttpClient http, int pageSize, int pageIndex, bool filterAccess)
        {
            var uri = QueryHelpers.AddQueryString("documenttemplates/list", new Dictionary<string, string>
            {
                { "pageSize", pageSize.ToString() },
                { "pageIndex", pageIndex.ToString() },
                { "filterAccess", filterAccess.ToString() }
            });

            var responseMessage = await http.GetAsync(uri);

            if (!responseMessage.IsSuccessStatusCode)
                throw await ApiException.Create(responseMessage);

            return await responseMessage.Content.ReadAsAsync<DocumentTemplatesResponse>();
        }
    }
}