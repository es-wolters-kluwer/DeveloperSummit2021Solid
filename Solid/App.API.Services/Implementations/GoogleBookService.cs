namespace App.Domain.API.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using App.Domain.Resources;
    using App.Infrastructure.Serialization;

    public class GoogleBookService : IGoogleBookService
    {
        private readonly HttpClient httpClient;
        private readonly IAppSerializer serializer;

        public GoogleBookService(IAppSerializer serializer, IHttpClientFactory factory)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));

            //HttpFactory creates httpClient configured
            this.httpClient = factory.CreateClient("GoogleBooks");
        }

        public void Dispose()
        {
            this.httpClient?.Dispose();
            this.serializer?.Dispose();
        }

        public async Task<IApiResponseResource> SearchFromVolumes(string query)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"volumes?q={query}").ConfigureAwait(false);

                if (response.IsSuccessStatusCode == false)
                    throw new Exception($"Error Code: {response.StatusCode}");

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return this.serializer.Deserialize<IApiResponseResource>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HttpException {ex.Message}");
            }
        }
    }
}
