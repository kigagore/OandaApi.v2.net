using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OandaApi.v20.Model;

namespace OandaApi.v20.Api.Endpoints
{
    public abstract class RestEndpointBase : EndpointBase
    {
        public RestEndpointBase(Func<HttpClient> httpClientResolver, OandaConfig config) : base(httpClientResolver, config)
        {
        }
        
        protected async Task<ApiResponse<T>> SendRequestAsync<T>(HttpRequestMessage request) where T: class
        {
            var httpClient = HttpClientResolver();
            var response = await httpClient.SendAsync(request);
            var responseStr = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var resultObj = JsonConvert.DeserializeObject<T>(responseStr, Serializing.GetSerializerSettings());
                return ApiResponse<T>.CreateSuccessResponse(resultObj);
            }
            var errObject = JsonConvert.DeserializeObject<ApiError>(responseStr, Serializing.GetSerializerSettings());
            return ApiResponse<T>.CreateErrorResponse<T>(errObject);
        }
    }
}