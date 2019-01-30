using System;
using System.Net.Http;
using System.Threading.Tasks;
using OandaApi.v20.Model;

namespace OandaApi.v20.Api.Endpoints.Instrument
{
    public class InstrumentEndpoint : EndpointBase, IInstrumentEndpoint
    {
        private const string GetCandlesticksEndpointFormat = "/v3/instruments/{0}/candles";
        
        public InstrumentEndpoint(Func<HttpClient> httpClientResolver, OandaConfig config) : base(httpClientResolver, config)
        {
        }

        public Task<ApiResponse<GetCandlesResponse>> GetCandlesticksAsync(GetCandlesRequest request)
        {
            var httpRequestMessage = CreateRequest(HttpMethod.Get, string.Format(GetCandlesticksEndpointFormat, request.InstrumentName) + request.ToQueryString());
            return SendRequestAsync<GetCandlesResponse>(httpRequestMessage);
        }
    }
}