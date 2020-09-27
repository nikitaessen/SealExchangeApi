using System.Web.Http;
using Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SealExchangeApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ExchangeApi",
                routeTemplate: "api/{controller}/{amount}",
                defaults: new { amount = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            app.UseWebApi(config);
        }
    }
}