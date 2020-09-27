using System.Web.Configuration;

namespace SealExchangeApi
{
    public static class ApiSettings
    {
        /// <summary>
        /// Main site Url with http://.
        /// </summary>
        static public string BaseUrl { get; set; }

        static public string ExchangeHost { get; set; }

        static public string AppId { get; set; }

        static ApiSettings()
        {
            // Cache all these values in static properties.
            BaseUrl = WebConfigurationManager.AppSettings["BaseUrl"];
            ExchangeHost = WebConfigurationManager.AppSettings["ExchangeHost"];
            AppId = WebConfigurationManager.AppSettings["AppId"];
        }
    }
}
