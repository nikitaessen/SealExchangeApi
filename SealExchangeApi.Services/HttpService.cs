using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SealExchangeApi.Services
{
    public class HttpService
    {
        private HttpClient _client;

        public HttpService()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            return await _client.GetAsync(uri);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return await _client.GetAsync(uri);
        }

        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> Post(Uri uri, HttpContent content)
        {
            return await _client.PostAsync(uri, content);
        }

        public void SetRequestHeader(string headerName, string value)
        {
            _client.DefaultRequestHeaders.Add(headerName, value);
        }
    }
}