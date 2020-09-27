using Newtonsoft.Json;
using System.Collections.Generic;

namespace SealExchangeApi.Models
{
    public class ExchangeRates
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("rates")]
        public string Rates { get; set; }
    }
}