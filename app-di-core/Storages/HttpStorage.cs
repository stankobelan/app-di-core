using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using homework.Wrapper;

namespace homework
{
    public class HttpStorage : IStorage
    {
        private readonly string _url;
        private readonly IHttpClientWrapper _client;
        public HttpStorage(string url, IHttpClientWrapper client)
        {
            _url = url;
            _client = client;
        }

        public async Task<Stream> Load()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            
            var response = await _client.SendAsync(request);

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
            var inputData = new StreamContent(data);
            var response = await _client.PostAsync(_url, inputData);

            return response.IsSuccessStatusCode;
        }
    }
}
