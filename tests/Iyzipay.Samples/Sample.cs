using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class Sample
    {
        protected Options Options;

        [SetUp]
        public void Initialize()
        {
            Options = new Options
            {
                ApiKey = "api key",
                SecretKey = "secret key",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };
        }

        protected void PrintResponse<T>(T resource)
        {
#if NETCORE1 || NETCORE2
            TraceListener consoleListener = new TextWriterTraceListener(System.Console.Out);
#else
            TraceListener consoleListener = new ConsoleTraceListener();
#endif
            Trace.Listeners.Add(consoleListener);
            Trace.WriteLine(JsonConvert.SerializeObject(resource, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
