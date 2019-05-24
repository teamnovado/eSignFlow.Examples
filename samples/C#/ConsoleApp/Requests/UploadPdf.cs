using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConsoleApp.Tests;

namespace ConsoleApp.Requests
{
    class UploadPdf
    {
        public static async Task<Guid> Execute(HttpClient http, Stream pdf, string fileName)
        {
            using (var content = new MultipartFormDataContent())
            using (var fileContent = new StreamContent(pdf))
            {
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                content.Add(fileContent);

                var responseMessage = await http.PostAsync("Documents/Post", content);

                if (!responseMessage.IsSuccessStatusCode)
                    throw await ApiException.Create(responseMessage);

                var response = await responseMessage.Content.ReadAsStringAsync();

                return Guid.Parse(response.Trim('"'));
            }
        }
    }
}