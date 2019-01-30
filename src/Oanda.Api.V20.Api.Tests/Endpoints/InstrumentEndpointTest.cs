using System;
using System.Net.Http;
using System.Threading.Tasks;
using OandaApi.v20.Api.Endpoints.Instrument;
using OandaApi.v20.Model;
using OandaApi.v20.Model.Enum;
using Xunit;
using Xunit.Sdk;

namespace Oanda.Api.V20.Api.Tests.Endpoints
{
    public class InstrumentEndpointTest : EndpointTestContext
    {
        private readonly InstrumentEndpoint _instrumentEndpointTest;
        
        public InstrumentEndpointTest() : base()
        {
            _instrumentEndpointTest = new InstrumentEndpoint(ResolveHttpClient, OandaConfig);
        }

        [Fact]
        private async Task GetCandlesticks()
        {
            var request = new GetCandlesRequest
            {
                InstrumentName = "EUR_USD",
                PriceType = "mid",
                From = new DateTime(2019, 01, 10),
                Granularity = CandlestickGranularity.M5,
                Count = 50
            };
            var response = await _instrumentEndpointTest.GetCandlesticksAsync(request);
        }
    }
}