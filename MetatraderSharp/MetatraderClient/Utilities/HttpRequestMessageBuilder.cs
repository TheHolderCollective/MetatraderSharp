using System.Net.Http.Headers;

namespace MetatraderSharp.MetatraderClient;

internal static class HttpRequestMessageBuilder
{
    public static HttpRequestMessage BuildHttpGetRequest(string uri)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri),
            Headers = { { "Accept", "application/json" } }
        };
    }

    public static HttpRequestMessage BuildHttpPostRequest(string uri)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri),
            Headers = { { "Accept", "application/json" } }
        };
    }

    public static HttpRequestMessage BuildHttpPostRequest(string uri, string requestContent)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri),
            Headers = { { "Accept", "application/json" } },
            Content = new StringContent(requestContent)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            }
        };
    }
}
