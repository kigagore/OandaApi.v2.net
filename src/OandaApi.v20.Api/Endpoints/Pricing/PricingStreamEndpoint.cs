using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OandaApi.v20.Model;
using OandaApi.v20.Model.Enum;
using OandaApi.v20.Model.Pricing;

namespace OandaApi.v20.Api.Endpoints.Pricing
{
    public class PricingStreamEndpoint : StreamingEndpointBase, IPricingStreamEndpoint
    {
        private const string PricingEndpointFormat = "/v3/accounts/{0}/pricing/stream";
        public PricingStreamEndpoint(Func<HttpClient> httpClientResolver, OandaConfig config) : base(httpClientResolver, config)
        {
        }

        public async Task<StreamApiResponse<IPricingData>> GetPricingStream(GetPricingStreamRequest request)
        {
            var httpRequest = CreateAuthorizedStreamRequest(HttpMethod.Get,
                string.Format(PricingEndpointFormat, request.AccountId) + request.ToQueryString());
            var httpClient = HttpClientResolver();
            var response = await httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            if (response.IsSuccessStatusCode)
            {
                return new StreamApiResponse<IPricingData>(response.Content, new PricingItemConverter());
            }

            var responseStr = await response.Content.ReadAsStringAsync();
            var apiError = JsonConvert.DeserializeObject<ApiError>(responseStr, Serializing.GetSerializerSettings());
            return new StreamApiResponse<IPricingData>(apiError);
            //return ApiResponse<T>.CreateErrorResponse<T>(errObject, response.StatusCode);
        }
    }
}