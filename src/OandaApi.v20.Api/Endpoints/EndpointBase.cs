using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OandaApi.v20.Api.Endpoints.Account;
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

        protected HttpRequestMessage CreateAuthorizedRestRequest(HttpMethod method, string endpoint)
        {
            return CreateAuthorizedRestRequest(method, endpoint, _config.RestApiUrl);
        }
        
        protected HttpRequestMessage CreateAuthorizedStreamRequest(HttpMethod method, string endpoint)
        {
            return CreateAuthorizedRestRequest(method, endpoint, _config.StreamingApiUrl);
        }
        
        private HttpRequestMessage CreateAuthorizedRestRequest(HttpMethod method, string endpoint, Uri uri)
        {
            var request = new HttpRequestMessage(method, new Uri(uri, endpoint));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config.AccessToken); //AuthenticationHeaderValue.Parse(_config.AccessToken);
            return request;
        }
    }
}