using System;
using System.Net.Http;
using System.Net.Http.Headers;
using OandaApi.v20.Model;

namespace OandaApi.v20.Api.Endpoints
{
    public abstract class EndpointBase
    {
        protected readonly Func<HttpClient> HttpClientResolver;
        private readonly OandaConfig _config;

        protected EndpointBase(Func<HttpClient> httpClientResolver, OandaConfig config)
        {
            HttpClientResolver = httpClientResolver;
            _config = config;
        }

        protected HttpRequestMessage CreateRequest(HttpMethod method, string endpoint)
        {
            var request = new HttpRequestMessage(method, new Uri(_config.RestApiUrl, endpoint));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config.AccessToken); //AuthenticationHeaderValue.Parse(_config.AccessToken);
            return request;
        }
    }
}