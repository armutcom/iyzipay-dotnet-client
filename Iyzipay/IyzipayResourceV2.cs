using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Armut.Iyzipay
{
    public class IyzipayResourceV2
    {
        private static readonly string CONVERSATION_ID_HEADER_NAME = "x-conversation-id";
        private static readonly string IYZIWS_V2_HEADER_NAME = "IYZWSv2 ";
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ConversationId { get; set; }
        public long SystemTime { get; set; }

        public void AppendWithHttpResponseHeaders(HttpResponseMessage httpResponseMessage)
        {
            HttpHeaders responseHeaders = httpResponseMessage.Headers;
            StatusCode = Convert.ToInt32(httpResponseMessage.StatusCode);

            if (responseHeaders.TryGetValues(CONVERSATION_ID_HEADER_NAME, out IEnumerable<string> values))
            {
                string conversationId = values.First();
                ConversationId = !string.IsNullOrWhiteSpace(conversationId) ? conversationId : null;
            }
        }

        protected static WebHeaderCollection GetHttpHeadersWithRequestBody(BaseRequestV2 request, string url, Options options)
        {
            WebHeaderCollection headers = GetCommonHttpHeaders(request);
            string authHeader = PrepareAuthorizationStringWithRequestBody(request, url, options);

#if NETSTANDARD
            headers[Constants.AUTHORIZATION] = authHeader;
#else
            headers.Add(Constants.AUTHORIZATION, authHeader);
#endif
            return headers;
        }

        protected static WebHeaderCollection GetHttpHeadersWithUrlParams(BaseRequestV2 request, string url, Options options)
        {
            WebHeaderCollection headers = GetCommonHttpHeaders(request);
            string authHeader = PrepareAuthorizationStringWithUrlParam(url, options);

#if NETSTANDARD
            headers[Constants.AUTHORIZATION] = authHeader;
#else
            headers.Add(Constants.AUTHORIZATION, authHeader);
#endif
            return headers;
        }

        private static WebHeaderCollection GetCommonHttpHeaders(BaseRequestV2 request)
        {
            WebHeaderCollection headers = new WebHeaderCollection();

#if NETSTANDARD
            headers["Accept"] = "application/json";
            headers[Constants.CLIENT_VERSION_HEADER] = Constants.CLIENT_VERSION;
            headers[CONVERSATION_ID_HEADER_NAME] = request.ConversationId;
#else
            headers.Add("Accept", "application/json");
            headers.Add(Constants.CLIENT_VERSION_HEADER, Constants.CLIENT_VERSION);
            headers.Add(CONVERSATION_ID_HEADER_NAME, request.ConversationId);
#endif
            return headers;
        }

        private static string PrepareAuthorizationStringWithRequestBody(BaseRequestV2 request, string url, Options options)
        {
            string randomKey = GenerateRandomKey();
            string uriPath = FindUriPath(url);
            string payload = request != null ? uriPath + JsonBuilder.SerializeObjectToPrettyJson(request) : uriPath;
            string dataToEncrypt = randomKey + payload;
            string hash = HashGeneratorV2.GenerateHash(options.ApiKey, options.SecretKey, randomKey, dataToEncrypt);

            return IYZIWS_V2_HEADER_NAME + hash;
        }

        private static string PrepareAuthorizationStringWithUrlParam(string url, Options options)
        {
            string randomKey = GenerateRandomKey();
            string uriPath = FindUriPath(url);
            string dataToEncrypt = randomKey + uriPath;
            string hash = HashGeneratorV2.GenerateHash(options.ApiKey, options.SecretKey, randomKey, dataToEncrypt);

            return IYZIWS_V2_HEADER_NAME + hash;
        }

        private static string GenerateRandomKey()
        {
            return DateTime.Now.ToString("ddMMyyyyhhmmssffff");
        }

        private static string FindUriPath(string url)
        {
            int startIndex = url.IndexOf("/v2");
            int endIndex = url.IndexOf("?");
            int length = endIndex == -1 ? url.Length - startIndex : endIndex - startIndex;

            return url.Substring(startIndex, length);
        }
    }
}
