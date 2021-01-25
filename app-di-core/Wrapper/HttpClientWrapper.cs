using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace homework.Wrapper
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public HttpClientWrapper(HttpClient client)
        {
            this.client = client;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return await client.PostAsync(requestUri, content);
        }
    }
}
