using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    abstract class TestBase
    {
        protected static HttpClient Http { get; private set; }

        protected readonly TextWriter Logger;

        protected TestBase()
        {
            Logger = Console.Out;

            if (Http == null) CreateClient();
        }

        void CreateClient()
        {
            if (Http != null)
            {
                Http.Dispose();
                Http = null;
            }

            var baseUri = new Uri(ConfigurationManager.AppSettings["BaseUri"]);
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            var apiIdentityNrn = ConfigurationManager.AppSettings["ApiIdentityNrn"];

            Logger.WriteLine("Creating HttpClient using configuration parameters:");
            Logger.WriteLine("BaseUri: {0}", baseUri);
            Logger.WriteLine("ApiKey: {0}", apiKey);
            Logger.WriteLine("ApiIdentityNrn: {0}", apiIdentityNrn);
            Logger.WriteLine();

            Http = HttpClientFactory.Create();
            Http.BaseAddress = baseUri;
            Http.DefaultRequestHeaders.Add("X-eSignFlow-API-Key", apiKey);
            Http.DefaultRequestHeaders.Add("X-eSignFlow-Identity-NRN", apiIdentityNrn);
        }

        protected string Serialize(object o)
        {
            var settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(o, settings);
        }

        public async Task Execute()
        {
            try
            {
                Logger.WriteLine("Running test {0}", GetType().Name);
                Logger.WriteLine();

                await ExecuteInternal();
            }
            catch (ApiException ex)
            {
                Logger.WriteLine("Api Exception: {0}", ex.Message);

                if (ex.ApiError != null)
                {
                    Logger.WriteLine();
                    Logger.WriteLine(Serialize(ex.ApiError));
                }
            }
            catch (HttpRequestException ex)
            {
                Logger.WriteLine("Http Exception: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Logger.WriteLine("An unexpected error occurred: {0}", ex.Message);
            }

            Logger.WriteLine();

        }

        protected abstract Task ExecuteInternal();
    }
}