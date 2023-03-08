using Microsoft.AspNetCore.Mvc.Formatters;

namespace DadJoke
{
    public class HtmlOutputFormatter : StringOutputFormatter
    {
        public HtmlOutputFormatter()
        {
            SupportedMediaTypes.Add("text/html");
            SupportedMediaTypes.Add("text/plain");
            SupportedMediaTypes.Add("appli");
        }
    }
}
