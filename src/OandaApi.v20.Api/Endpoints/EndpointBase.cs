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

        protected HttpRequestMessage CreateRequest(HttpMethod method, string endpoint)
        {
            var request = new HttpRequestMessage(method, new Uri(_config.RestApiUrl, endpoint));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config.AccessToken); //AuthenticationHeaderValue.Parse(_config.AccessToken);
            return request;
        }

        protected async Task<ApiResponse<T>> SendRequestAsync<T>(HttpRequestMessage request) where T: class
        {
            var httpClient = HttpClientResolver();
            var response = await httpClient.SendAsync(request);
            var responseStr = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var resultObj = JsonConvert.DeserializeObject<T>(responseStr, Serializing.GetSerializerSettings());
                return ApiResponse<T>.CreateSuccessResponse(resultObj, response.StatusCode);
            }
            var errObject = JsonConvert.DeserializeObject<ApiError>(responseStr, Serializing.GetSerializerSettings());
            return ApiResponse<T>.CreateErrorResponse<T>(errObject, response.StatusCode);
        }
    }
}