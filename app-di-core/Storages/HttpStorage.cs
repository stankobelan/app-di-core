using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace homework
{
    public class HttpStorage : IStorage
    {
        private readonly string _url;
        private readonly IHttpClientFactory _clientFactory;
        public HttpStorage(string url, IHttpClientFactory clientFactory)
        {
            _url = url;
            _clientFactory = clientFactory;
        }

        public async Task<Stream> Load()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Save(Stream data)
        {
            var client = _clientFactory.CreateClient();
            var inputData = new StreamContent(data);
            var response = await client.PostAsync(_url, inputData);

            return response.IsSuccessStatusCode;
        }
    }
}
