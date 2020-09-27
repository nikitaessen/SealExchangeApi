using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SealExchangeApi.Services
{
    public class OpenExchangeApiService
    {
        private const string DOCUMENT_PATH_FRAGMENT = "latest.json";

        private readonly UriMaker _uriMaker;
        private readonly HttpService _httpService;

        public OpenExchangeApiService()
        {
            _uriMaker = new UriMaker();
            _httpService = new HttpService();
        }

        public async Task<string> FetchLatestExchange(string hostName, string appId)
        {
            var requestUrl = _uriMaker.Combine(hostName, DOCUMENT_PATH_FRAGMENT);
            var query = _uriMaker.CombineQuery(requestUrl, appId);

            var response = await _httpService.GetAsync(query);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
