using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Bazaar.Voice
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            GetData(config);
        }

        public static void GetData(IConfiguration config)
        {
            int limit = 5; int offset = 0;

            using (var client = new HttpClient())
            {
                var uriBuilder = new UriBuilder("https://api.bazaarvoice.com/data/reviews.json");
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["ApiVersion"] = config["apiversion"];
                query["passkey"] = config["apikey"];
                query["limit"] = limit.ToString();
                query["offset"] = offset.ToString();
                uriBuilder.Query = query.ToString();

                var response = client.GetStringAsync(uriBuilder.ToString());
                response.Wait();

                File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}/result.json", JsonPrettify(response.Result));
            }
        }

        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}
