using System.Web.Http;
using WebApiSample.MediaTypeFormatters;

namespace WebApiSample
{
    public class MediaTypeFormatterConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Formatters.Insert(0, new MonkeyMediaTypeFormatter());
            configuration.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}