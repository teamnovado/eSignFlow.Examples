using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.Models;

namespace ConsoleApp.Tests
{
    class ApiException : ApplicationException
    {
        public ErrorModel ApiError { get; private set; }

        private ApiException(HttpResponseMessage response)
            : base($"{(int)response.StatusCode} {response.ReasonPhrase}")
        {
        }

        public static async Task<ApiException> Create(HttpResponseMessage response)
        {
            return new ApiException(response)
            {
                ApiError = await response.Content.ReadAsAsync<ErrorModel>()
            };
        }
    }
}