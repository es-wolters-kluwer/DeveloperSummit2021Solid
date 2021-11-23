namespace ConsoleApp
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ConsoleApp.Entities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Consulta api https://www.googleapis.com/books/v1/");

            try
            {
                //Config serializer
                JsonSerializer serializer = new JsonSerializer()
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.None,
                    DateParseHandling = DateParseHandling.DateTime,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                //Config http client

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");

                ApiResponseResource resource = null;

                //Read parameters from console

                Console.Write("Insert search parameters and press enter: ");
                string search = Console.ReadLine();
                Console.WriteLine();

                if (String.IsNullOrWhiteSpace(search))
                    throw new Exception("Empty search terms");

                //Call API
                try
                {
                    await using Stream s = await client.GetStreamAsync($"volumes?q={search}").ConfigureAwait(false);
                    using StreamReader sr = new StreamReader(s);
                    using JsonReader reader = new JsonTextReader(sr);

                    resource = serializer.Deserialize<ApiResponseResource>(reader);

                    if (resource?.TotalItems == 0)
                        throw new Exception("Not items found");
                }
                //Error handling
                catch (HttpRequestException ex)
                {
                    throw new Exception($"HttpException {ex.Message}");
                }

                
                //Process only the first result on response
                await using var writer = new StringWriter();
                using var jsonWriter = new JsonTextWriter(writer);

                serializer.Serialize(jsonWriter, resource?.Items[0]);
                var indentedResponse = writer.ToString();

                Console.WriteLine("----- First result -----");
                Console.WriteLine(indentedResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("Pulsa cualquier tecla para cerrar");
            Console.ReadKey();
        }
    }
}
