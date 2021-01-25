using System.Net.Http;
using System.Threading.Tasks;

namespace homework.Wrapper
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}