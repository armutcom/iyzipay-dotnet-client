using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Armut.Iyzipay
{
    public class RestHttpClient
    {
        private static readonly HttpClient HttpClient;

        static RestHttpClient()
        {
#if !NETSTANDARD
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
            HttpClient = new HttpClient();
        }

        private RestHttpClient()
        {
        }

        public static RestHttpClient Create()
        {
            return new RestHttpClient();
        }

        public static void SetTimeout(short seconds)
        {
            HttpClient.Timeout = new TimeSpan(0, 0, seconds);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(url);
            string strContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(strContent);
        }

        public T Get<T>(string url)
        {
            return GetAsync<T>(url).Result;
        }

        public async Task<T> PostAsync<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Content = JsonBuilder.ToJsonString(request),
                Method = HttpMethod.Post,
                RequestUri = new Uri(url, UriKind.Absolute)
            };

            foreach (string key in headers.AllKeys)
            {
                requestMessage.Headers.Add(key, headers[key]);
            }

            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(requestMessage);
            string strContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(strContent);
        }

        public T Post<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            return PostAsync<T>(url, headers, request).Result;
        }

        public async Task<T> DeleteAsync<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Content = JsonBuilder.ToJsonString(request),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url, UriKind.Absolute)
            };

            foreach (string key in headers.AllKeys)
            {
                requestMessage.Headers.Add(key, headers[key]);
            }

            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(requestMessage);
            string strContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(strContent);
        }

        public T Delete<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            return DeleteAsync<T>(url, headers, request).Result;
        }

        public async Task<T> PutAsync<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Content = JsonBuilder.ToJsonString(request),
                Method = HttpMethod.Put,
                RequestUri = new Uri(url, UriKind.Absolute)
            };

            foreach (string key in headers.AllKeys)
            {
                requestMessage.Headers.Add(key, headers[key]);
            }

            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(requestMessage);
            string strContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(strContent);
        }

        public T Put<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            return PutAsync<T>(url, headers, request).Result;
        }
    }
}

