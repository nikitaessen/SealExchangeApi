using SealExchangeApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SealExchangeApi.Controllers
{
    public class ExchangeController : ApiController
    {
        private readonly OpenExchangeApiService _openExchangeApiService;

        public ExchangeController()
        {
            _openExchangeApiService = new OpenExchangeApiService();
        }

        public async Task<string> Get()
        {
            return await _openExchangeApiService.FetchLatestExchange(ApiSettings.ExchangeHost, $"app_id={ApiSettings.AppId}");
        }
    }
}